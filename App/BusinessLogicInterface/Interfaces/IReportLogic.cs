using System;
using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogicInterface.Interfaces
{
    public interface IReportLogic
    {
        List<Report> GetHousesReportBy(DateTime dateFrom, DateTime dateOut,int  idTp);
    }
}