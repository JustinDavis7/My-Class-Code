using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HW2.Models;
using HW2.DAL.Abstract;
using HW2.DAL.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW2.ViewModels
{
    public class StatsVM
    {
        private readonly IShowRepository _showRepo;
        private readonly IPeopleRepository _peopleRepo;
        private readonly IGenreRepository _genreRepo;
        public readonly int totalShows;
        public readonly int movieCount;
        public readonly int tvCount;
        public readonly Show highestTMDBPop;
        public readonly Show mostIMBDV;
        public readonly Show oldest;
        public readonly Show newest;

        public readonly int actorOccuranceCount;
        public readonly string actorWhoOccuredMost;

        public readonly IList<Genre> top5Genres;
        public readonly SelectList allGenres;

        public string genreChoice {get; set;}
        public int pickedType {get; set;}
        public List<string> highest10ShowsInGenreStrings {get; set;}
        public List<string[]> highest10ShowsList {get; set;}
        
        public StatsVM()
        {

        }
        public StatsVM(IShowRepository showRepository, IPeopleRepository peopleRepository, IGenreRepository genreRepository)
        {
            _showRepo = showRepository;
            _peopleRepo = peopleRepository;
            _genreRepo = genreRepository;

            totalShows = _showRepo.NumberOfShowsByType().Item1;
            movieCount = _showRepo.NumberOfShowsByType().Item2;
            tvCount = _showRepo.NumberOfShowsByType().Item3;
            highestTMDBPop = _showRepo.HighestTMDBPopularity();
            mostIMBDV = _showRepo.MostIMDBVotes();
            oldest = _showRepo.Oldest();
            newest = _showRepo.Newest();
            if(genreChoice != null)
            {
                highest10ShowsInGenreStrings = _showRepo.HighestRatedShowInGenre10StringList(genreChoice, pickedType);
                highest10ShowsList = _showRepo.HighestRatedShowInGenre10Lists(highest10ShowsInGenreStrings);
            }

            actorWhoOccuredMost = _peopleRepo.HighestOccuranceActor().Item1;
            actorOccuranceCount = _peopleRepo.HighestOccuranceActor().Item2;

            top5Genres = _genreRepo.Top5GenresDescending();
            allGenres = new SelectList(_genreRepo.GetGenreList());
            
        }
    }   
}

    