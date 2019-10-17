using AutoMapper;
using Entities;
using TriCalcAngular.Models;

namespace TriCalcAngular.Support
{
    public class BasicMapperProfile: Profile
    {
        public BasicMapperProfile()
        {
            CreateMap<Race, RaceDTO>()
                .ForMember(vm => vm.RaceId, map => map.MapFrom(m => m.Race_id))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.Year, map => map.MapFrom(m => m.Year))
                .ForMember(vm => vm.RaceFormatId, map => map.MapFrom(m => m.Race_Format_id))
                .ForMember(vm => vm.RaceFormatName, map => map.Ignore())
                .ForMember(vm => vm.ResultsCount, map => map.MapFrom(m => m.Results.Count))


                ;
            CreateMap<Format, FormatDTO>()
                .ForMember(vm => vm.FormatId, map => map.MapFrom(m => m.Format_id))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.Results, map => map.Ignore());
                
            CreateMap<Athlete, AthleteDTO>()
                .ForMember(vm => vm.AthleteId, map => map.MapFrom(m => m.Athlete_id))
                .ForMember(vm => vm.FirstName, map => map.MapFrom(m => m.FirstName))
                .ForMember(vm => vm.LastName, map => map.MapFrom(m => m.LastName))
                .ForMember(vm => vm.DOB, map => map.MapFrom(m => m.DOB));

            CreateMap<Result, ResultDTO>()
                .ForMember(vm => vm.ResultId, map => map.MapFrom(m => m.Result_Id))
                .ForPath(vm => vm.ResultAthlete.FirstName, map => map.MapFrom(m => m.Athlete.FirstName))
                .ForPath(vm => vm.ResultAthlete.LastName, map => map.MapFrom(m => m.Athlete.LastName))
                .ForPath(vm => vm.ResultRace.Name, map => map.MapFrom(m => m.Race.Name))
                .ForMember(vm => vm.TimeSwim, map => map.MapFrom(m => m.Time_Swim))
                .ForMember(vm => vm.TimeT1, map => map.MapFrom(m => m.Time_T1))
                .ForMember(vm => vm.TimeBike, map => map.MapFrom(m => m.Time_Bike))
                .ForMember(vm => vm.TimeT2, map => map.MapFrom(m => m.Time_T2))
                .ForMember(vm => vm.TimeRun, map => map.MapFrom(m => m.Time_Run))
                .ForMember(vm => vm.TimeTotal, map => map.MapFrom(m => m.Time_Total))
                .ForMember(vm => vm.ResultAthleteId, map => map.MapFrom(m => m.Result_Athlete_Id))
                .ForMember(vm => vm.ResultRaceId, map => map.MapFrom(m => m.Result_Race_Id))
                ;

            //other way round
            CreateMap<RaceDTO, Race>()
                .ForMember(vm => vm.Race_id, map => map.Ignore())
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.Year, map => map.MapFrom(m => m.Year))
                .ForMember(vm => vm.Race_Format_id, map => map.MapFrom(m => m.RaceFormatId))
                .ForMember(vm => vm.Results, map => map.Ignore())
                .ForMember(vm => vm.Format, map => map.Ignore())
                ;
            CreateMap<AthleteDTO, Athlete>()
                .ForMember(vm => vm.Athlete_id, map => map.Ignore())
                .ForMember(vm => vm.FirstName, map => map.MapFrom(m => m.FirstName))
                .ForMember(vm => vm.LastName, map => map.MapFrom(m => m.LastName))
                .ForMember(vm => vm.DOB, map => map.MapFrom(m => m.DOB));
        }
    }
}
