using Eliassen.System.ComponentModel;
using Eliassen.System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Nucleus.Core.Contracts.Models
{
    [Searchable(FirstNameLastName)]
    [Searchable(LastNameFirstName)]
    [DebuggerDisplay("{FirstName} {LastName}")]
    public class User
    {
        public const string FirstNameLastName = nameof(FirstNameLastName);
        public const string LastNameFirstName = nameof(LastNameFirstName);
        public const string Module = nameof(Module);
        public const string UserStatus = nameof(UserStatus);

        public string? UserId { get; set; }
        public string? UserName { get; set; }

        [Searchable]
        [DefaultSort(priority: 2, order: OrderDirections.Ascending)]
        public string? EmailAddress { get; set; }

        [Searchable]
        [DefaultSort(priority: 1, order: OrderDirections.Ascending)]
        public string? FirstName { get; set; }

        [Searchable]
        [DefaultSort(priority: 0, order: OrderDirections.Ascending)]
        public string? LastName { get; set; }

        public bool Active { get; set; }

        public List<UserModule>? UserModules { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public static Expression<Func<User, object>>? PropertyMap(string key) =>
            key switch
            {
                FirstNameLastName => e => e.FirstName + " " + e.LastName,
                LastNameFirstName => e => e.LastName + " " + e.FirstName,
                _ => null
            };

        public static Expression<Func<User, bool>>? PredicateMap(string key, object value) =>
            key switch
            {
                Module => e => e.UserModules.Any(um=>um.Code == value),
                UserStatus => e => value == "-1" || e.Active == (value == "1"),
                _ => null
            };

        /*
     }
            if (!string.IsNullOrEmpty(filterItems.UserStatus) && filterItems.UserStatus != "-1")
            {
                var statusBuilder = builder.Where(e => (
        
        filterItems.UserStatus == null || 
        filterItems.UserStatus == "-1" || 
        (filterItems.UserStatus == "1" && e.Active == true) || 
        (filterItems.UserStatus == "0" && e.Active == false)
        
        ));
                filter &= statusBuilder;
            }
            if (!string.IsNullOrEmpty(filterItems.Module) && filterItems.Module != "module_authenticated")
            {
                var moduleBuilder = builder.Where(e =>  e.UserModules.Any(m => m.Code == filterItems.Module));
                filter &= moduleBuilder;
            }
        */


        //{nameof(userFilter.UserFilters.Module), new Eliassen.System.Linq.SearchOption{ EqualTo= userFilter.UserFilters.Module } },
        //{nameof(userFilter.UserFilters.UserStatus), new Eliassen.System.Linq.SearchOption{ EqualTo= userFilter.UserFilters.UserStatus } },

    }
}
