﻿using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class BookTitleRepository : BaseRepository<BookTitleEntity>, IBookTitleRepository
    {
        protected override DbSet<BookTitleEntity> DbSet => _context.BookTitles;
        public BookTitleRepository(ApplicationDbContext context) : base(context) { }
    }
}
