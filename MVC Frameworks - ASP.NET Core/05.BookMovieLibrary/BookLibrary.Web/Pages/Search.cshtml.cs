using BookLibrary.Data;
using BookLibrary.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookLibrary.Web.Pages
{
    public class SearchModel : PageModel
    {
        public SearchModel(BookLibraryContext context)
        {
            this.Context = context;
            this.SearchResults = new List<SearchViewModel>();
        }

        public BookLibraryContext Context { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<SearchViewModel> SearchResults { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(this.SearchTerm))
            {
                return;
            }

            var foundAuthors = this.Context.Authors
                .Where(a => a.Name.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(a => a.Name)
                .Select(a => new SearchViewModel()
                {
                    SearchResult = a.Name,
                    Id = a.Id,
                    Type = "Author"
                })
                .ToList();

            var foundBooks = this.Context.Books
                .Where(b => b.Title.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => new SearchViewModel()
                {
                    SearchResult = b.Title,
                    Id = b.Id,
                    Type = "Book"
                })
                .ToList();

            var foundDirectors = this.Context.Directors
                .Where(d => d.Name.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(d => d.Name)
                .Select(d => new SearchViewModel()
                {
                    SearchResult = d.Name,
                    Id = d.Id,
                    Type = "Director"
                })
                .ToList();

            var foundMovies = this.Context.Movies
                .Where(m => m.Title.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(m => m.Title)
                .Select(m => new SearchViewModel()
                {
                    SearchResult = m.Title,
                    Id = m.Id,
                    Type = "Movie"
                })
                .ToList();

            this.SearchResults.AddRange(foundAuthors);
            this.SearchResults.AddRange(foundBooks);
            this.SearchResults.AddRange(foundDirectors);
            this.SearchResults.AddRange(foundMovies);

            foreach (var result in this.SearchResults)
            {
                string markedResult = Regex.Replace(
                    result.SearchResult,
                    $"({Regex.Escape(this.SearchTerm)})",
                    match => $"<strong class=\"text-danger\">{match.Groups[0].Value}</strong>",
                    RegexOptions.IgnoreCase | RegexOptions.Compiled);
                result.SearchResult = markedResult;
            }
        }
    }
}