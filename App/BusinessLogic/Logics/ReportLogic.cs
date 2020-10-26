using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using BusinessLogicInterface.Interfaces;
using DataAccessInterface.Repositories;
using Domain.Entities;

namespace BusinessLogic.Logics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IReportRepository reportRepository;
        public ReportLogic(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }
       
         public List<Report> GetHousesReportBy(ReportTouristPoint touristPointReport)
         {
             // DateTime dateFrom, DateTime dateOut,int  idTp
             DateTime dateFrom = touristPointReport.dateFrom;
             DateTime dateOut = touristPointReport.dateOut;
             int idTp=touristPointReport.idTp;
             List<Report> housesWithBookingList = reportRepository.FilterCantBookigsByHouse(dateFrom,dateOut,idTp);
             return housesWithBookingList;
         }
    }
}