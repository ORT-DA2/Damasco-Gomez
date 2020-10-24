using System;
using System.Collections.Generic;
using Domain.Entities;

namespace DataAccessInterface.Repositories
{
    public class IReportRepository
    {
        List<Report> FilterCantBookigsByHouses (DateTime dateFrom, DateTime dateOn) ;
    }
}