using System;
using System.Collections.Generic;
using Domain.Entities;

namespace DataAccessInterface.Repositories
{
    public interface IReportRepository
    {
       List<Report> FilterCantBookigsByHouse (DateTime dateFrom, DateTime dateOut,int  idTp);
    }
}