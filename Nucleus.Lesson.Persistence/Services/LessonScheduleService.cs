using MongoDB.Driver;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using Nucleus.Lesson.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonScheduleCollection = Nucleus.Lesson.Contracts.Collections.LessonScheduleCollection;

namespace Nucleus.Lesson.Persistence.Services
{
    public class LessonScheduleService : ILessonScheduleService
    {
        private readonly ILessonMongoDatabase _db;
        private readonly ProjectionDefinition<LessonScheduleCollection, LessonScheduleModel>? _lessonProjection;
        private readonly BsonCollectionBuilder<LessonScheduleModel, LessonScheduleCollection> _lessonCollectionBuilder;

        public LessonScheduleService(
            ILessonMongoDatabase db
            )
        {
            _db = db;

            _lessonCollectionBuilder = new BsonCollectionBuilder<LessonScheduleModel, LessonScheduleCollection>();
            _lessonProjection = Builders<LessonScheduleCollection>.Projection.Expression(item => new LessonScheduleModel()
            {
                LessonId = item.LessonId,
                Title = item.Title,
                Slug = item.Slug,
                MediaLink = item.MediaLink,
                PreviewImage = item.PreviewImage,
                Preview = item.Preview,
                Content = item.Content,
                Enabled = item.Enabled,
                CreatedOn = item.CreatedOn,
                Teacher = item.Teacher,
                Duration    = item.Duration,
                Tags = item.Tags,
                Price = item.Price,
                Goals = item.Goals,
                StartDateTime = item.StartDateTime,
                EndDateTime = item.EndDateTime,
                Repeat = item.Repeat
            });
        }

        public DateTimeOffset GetEndDateTime(DateTimeOffset startDateTime, int? duration)
        {
            return startDateTime.AddMinutes(Convert.ToDouble(duration));
        }

        // need to extend/re-work this so I do not pass in multiple parameters to each method, just a proper filter item from the business layer
        private FilterDefinition<LessonScheduleCollection> GetLessonsPredicateBuilder(bool onlyActive, LessonsFilterItem? filterItems)
        {
            // Keeping this business logic in the access layer.  Cannot move it to the business layer yet
            // until I can create an extension that can translate for multiple database.  Moving this to db
            // layer forces you to include mongo drivers which will no longer make this a good solution to be
            // a hybrid database solution just by changing interfaces in the IOC
            var builder = Builders<LessonScheduleCollection>.Filter;
            var filter = builder.Empty;

            //if (onlyActive)
            //    filter &= builder.AnyEq("enabled", true);

            if (filterItems != null && !string.IsNullOrWhiteSpace(filterItems.InputValue))
            {
                var textSearch = builder.Text(filterItems.InputValue);
                filter &= textSearch;
            }

            return filter;
        }

#warning retire this
        public async Task<long> GetPagedCountAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive) =>
           await _db.LessonSchedule.Find(GetLessonsPredicateBuilder(onlyActive, filterItems)).CountDocumentsAsync();

        public async Task<List<LessonScheduleModel>> GetAsync() =>
            await _db.LessonSchedule.Find(_ => true).Project(_lessonProjection).ToListAsync();

        public async Task<List<LessonScheduleModel>> GetRecentAsync(int i, bool onlyActive) =>
           await _db.LessonSchedule.Find(_ => true)
               .Sort("{ \"createdOn\": -1}")
               .Limit(i)
               .Project(_lessonProjection).ToListAsync();

        public async Task<LessonScheduleModel?> GetSlugAsync(string slug, bool onlyActive) =>
            await _db.LessonSchedule.Find(x => x.Slug == slug).Project(_lessonProjection).FirstOrDefaultAsync();

        public async Task<LessonScheduleModel?> GetAsync(string id) =>
            await _db.LessonSchedule.Find(x => x.LessonId == id).Project(_lessonProjection).FirstOrDefaultAsync();

        public async Task<LessonScheduleModel> CreateAsync(LessonScheduleModel newLesson)
        {
            LessonScheduleCollection lesson = _lessonCollectionBuilder.BuildCollection(newLesson);
            await _db.LessonSchedule.InsertOneAsync(lesson);
            newLesson.LessonId = lesson.LessonId;
            return newLesson;
        }

        public async Task UpdateAsync(LessonScheduleModel updatedLesson) =>
            await _db.LessonSchedule.ReplaceOneAsync(x => x.LessonId == updatedLesson.LessonId, _lessonCollectionBuilder.BuildCollection(updatedLesson));

        public async Task RemoveAsync(string id) =>
            await _db.LessonSchedule.DeleteOneAsync(x => x.LessonId == id);

        public IQueryable<LessonScheduleModel> Query() =>
            _db.LessonSchedule.AsQueryable().Select(Projections.LessonSchedule);
    }
}
