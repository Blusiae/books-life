﻿using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BooksLife.Web
{
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;
        private readonly IAuthorManager _authorManager;

        public BookController(IBookManager bookManager, IAuthorManager authorManager)
        {
            _bookManager = bookManager;
            _authorManager = authorManager;
        }

        public IActionResult Index(Guid id)
        {
            var bookDto = _bookManager.Get(id);
            var bookViewModel = bookDto.ToViewModel();
            return View(bookViewModel);
        }

        public IActionResult Add()
        {
            var authorDtos = _authorManager.GetAll();
            ViewBag.Authors = authorDtos.ToViewModel();
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                var authorDtos = _authorManager.GetAll();
                ViewBag.Authors = authorDtos.ToViewModel();
                return View(bookViewModel);
            }

            var bookDto = bookViewModel.ToDto();
            var result = _bookManager.Add(bookDto);
            return RedirectToAction("List", result);
        }

        public IActionResult List(int? page, Response? response = null)
        {
            ViewBag.Response = response;

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var bookDtos = _bookManager.GetAll(pageSize, pageNumber, out int totalCount);
            var bookViewModels = bookDtos.ToViewModel();

            var pagedList = new StaticPagedList<BookViewModel>(bookViewModels, pageNumber, pageSize, totalCount);

            return View(pagedList);
        }

        public IActionResult Remove(Guid id)
        {
            var response = _bookManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
