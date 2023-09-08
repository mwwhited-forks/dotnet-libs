using MongoDB.Driver;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using Nucleus.Lesson.Contracts.Collections;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using Nucleus.Lesson.Contracts.Persistence;
using Nucleus.Lesson.Persistence.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Persistence.Services
{
    public class LessonAdminService : ILessonAdminService
    {
        private readonly ILessonMongoDatabase _db;
        private readonly ProjectionDefinition<LessonAdminCollection, LessonAdminModel>? _lessonProjection;
        private readonly BsonCollectionBuilder<LessonAdminModel, LessonAdminCollection> _lessonCollectionBuilder;

        public LessonAdminService(
            ILessonMongoDatabase db
            )
        {
            _db = db;

            _lessonCollectionBuilder = new BsonCollectionBuilder<LessonAdminModel, LessonAdminCollection>();
            _lessonProjection = Builders<LessonAdminCollection>.Projection.Expression(item => new LessonAdminModel()
            {
                LessonId = item.LessonId,
                //lessonadminid = item.lessonadminid,
                //lessondatetime = item.lessondatetime,
                //student = item.student,
                //notes = item.notes
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
        private FilterDefinition<LessonAdminCollection> GetLessonsPredicateBuilder(bool onlyActive, LessonsFilterItem? filterItems)
        {
            // Keeping this business logic in the access layer.  Cannot move it to the business layer yet
            // until I can create an extension that can translate for multiple database.  Moving this to db
            // layer forces you to include mongo drivers which will no longer make this a good solution to be
            // a hybrid database solution just by changing interfaces in the IOC
            var builder = Builders<LessonAdminCollection>.Filter;
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
        public async Task<List<LessonAdminModel>> GetPagedAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive)
        {
            // TODO: Make an extension that does all of this pagination plumbing
            string sortDefinition = $"{{ {pagingModel.SortBy}: 1 }}";
            if (pagingModel.SortDirection == "descend")
                sortDefinition = $"{{ {pagingModel.SortBy}: -1 }}";

            var bob = await _db.LessonAdmin.Find(GetLessonsPredicateBuilder(onlyActive, filterItems))
                .Skip((pagingModel.CurrentPage - 1) * pagingModel.PageSize)
                .Limit(pagingModel.PageSize)
                .Sort(sortDefinition)
                .Project(_lessonProjection)
                .ToListAsync();
            var joe = new List<LessonAdminModel>
            {
                new LessonAdminModel
                {
                    Title = "Test",
                    Teacher = "John Smith",
                    Enabled = true
                },
                new LessonAdminModel
                {
                    Title = "Test2",
                    Teacher = "Tony Tonyton",
                    Enabled = true
                },
                new LessonAdminModel
                {
                    Title = "Test3",
                    Teacher = "Joe Joeyson",
                    Enabled = true
                },
                new LessonAdminModel
                {
                    Title = "Test4",
                    Teacher = "adele test",
                    Enabled = true
                },

            };
            return bob;
        }
#warning retire this
        public async Task<long> GetPagedCountAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive) =>
           await _db.LessonAdmin.Find(GetLessonsPredicateBuilder(onlyActive, filterItems)).CountDocumentsAsync();

        public async Task<List<LessonAdminModel>> GetAsync() =>
            await _db.LessonAdmin.Find(_ => true).Project(_lessonProjection).ToListAsync();

        public async Task<List<LessonAdminModel>> GetRecentAsync(int i, bool onlyActive) =>
           await _db.LessonAdmin.Find(_ => true)
               .Sort("{ \"createdOn\": -1}")
               .Limit(i)
               .Project(_lessonProjection).ToListAsync();

        //public async Task<LessonModel?> GetSlugAsync(string slug, bool onlyActive) =>
        //    await _db.Lessons.Find(x => x.Slug == slug).Project(_lessonProjection).FirstOrDefaultAsync();

        public async Task<LessonAdminModel?> GetAsync(string id) =>
            await _db.LessonAdmin.Find(x => x.LessonId == id).Project(_lessonProjection).FirstOrDefaultAsync();

        public async Task<LessonAdminModel> CreateAsync(LessonAdminModel newLesson)
        {
            LessonAdminCollection lesson = _lessonCollectionBuilder.BuildCollection(newLesson);
            await _db.LessonAdmin.InsertOneAsync(lesson);
            newLesson.LessonId = lesson.LessonId;
            return newLesson;
        }

        public async Task UpdateAsync(LessonAdminModel updatedLesson) =>
            await _db.LessonAdmin.ReplaceOneAsync(x => x.LessonId == updatedLesson.LessonId, _lessonCollectionBuilder.BuildCollection(updatedLesson));

        public async Task RemoveAsync(string id) =>
            await _db.LessonAdmin.DeleteOneAsync(x => x.LessonId == id);

        public IQueryable<LessonAdminModel> Query() =>
            _db.LessonAdmin.AsQueryable().Select(Projections.LessonAdmin);
    }
}
