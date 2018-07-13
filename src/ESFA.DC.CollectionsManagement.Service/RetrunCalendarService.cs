﻿using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.CollectionsManagement.Data;
using ESFA.DC.CollectionsManagement.Interfaces;
using ESFA.DC.CollectionsManagement.Models;
using ESFA.DC.DateTime.Provider.Interface;

namespace ESFA.DC.CollectionsManagement.Services
{
    public class RetrunCalendarService : IRetrunCalendarService
    {
        private readonly CollectionsManagementContext _collectionsManagementContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        public RetrunCalendarService(CollectionsManagementContext collectionsManagementContext, IDateTimeProvider dateTimeProvider)
        {
            _collectionsManagementContext = collectionsManagementContext;
            _dateTimeProvider = dateTimeProvider;
        }
        public ReturnPeriod GetCurrentPeriod(string collectionName)
        {
            var currentDateTime = _dateTimeProvider.GetNowUtc();
            var periods = _collectionsManagementContext.ReturnPeriods.Where(x =>
                    x.Collection.Name == collectionName &&
                    x.StartDateTimeUtc >= currentDateTime
                    && currentDateTime <= x.EndDateTimeUtc)
                .Select(x => new ReturnPeriod()
                {
                    PeriodName = x.PeriodName,
                    EndDateTimeUtc = x.EndDateTimeUtc,
                    StartDateTimeUtc = x.StartDateTimeUtc,
                    CalendarMonth = x.CalendarMonth,
                    CalendarYear = x.CalendarYear,
                    CollectionName = x.Collection.Name
                });
            return periods.SingleOrDefault();
        }
    }
}
