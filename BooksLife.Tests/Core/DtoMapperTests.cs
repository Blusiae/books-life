﻿using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class DtoMapperTests
    {
        [Fact]
        public void Map_ForAuthorEntityObject_ShouldReturnAuthorDtoObjectWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorEntity = new AuthorEntity { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorDto = mapper.Map(authorEntity);

            authorDto.Should().BeOfType<AuthorDto>();
            authorDto.Should().BeEquivalentTo(authorEntity);
        }

        [Fact]
        public void Map_ForAuthorDtoObject_ShouldReturnAuthorEntityObjectWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorDto = new AuthorDto{ Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorEntity = mapper.Map(authorDto);

            authorEntity.Should().BeOfType<AuthorEntity>();
            authorEntity.Should().BeEquivalentTo(authorDto);
        }

        [Fact]
        public void Map_ForListOfAuthorEntityObjects_ShouldReturnListOfAuthorDtoObjectsWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorEntities = new List<AuthorEntity>()
            {
                new AuthorEntity { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorEntity { Id = Guid.NewGuid(), Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorEntity { Id = Guid.NewGuid(), Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorDtos = mapper.Map(authorEntities);

            authorDtos.Should().BeOfType<List<AuthorDto>>();
            authorDtos.Should().BeEquivalentTo(authorEntities);
        }

        [Fact]
        public void Map_ForListOfAuthorDtoObjects_ShouldReturnListOfAuthorEntityObjectsWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorDtos = new List<AuthorDto>()
            {
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorEntities = mapper.Map(authorDtos);

            authorEntities.Should().BeOfType<List<AuthorEntity>>();
            authorEntities.Should().BeEquivalentTo(authorDtos);
        }

        [Fact]
        public void Map_ForReaderEntity_ShouldReturnReaderDtoWithCorrectPropertiesAndAddressIncluded()
        {
            var mapper = new DtoMapper();
            var readerEntity = new ReaderEntity()
            {
                Id = Guid.NewGuid(),
                Firstname = "Firstname1",
                Lastname = "Lastname1",
                Birthdate = new DateTime(2000, 10, 11),
                EmailAddress = "email.address@email.com"
            };
            var addressEntity = new AddressEntity()
            {
                Id = Guid.NewGuid(),
                Country = "Poland",
                City = "Warsaw"
            };
            readerEntity.Address = addressEntity;
            readerEntity.AddressId = addressEntity.Id;

            var readerDto = mapper.Map(readerEntity);

            readerDto.Should().BeOfType<ReaderDto>();
            readerDto.Should().BeEquivalentTo(readerEntity, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForReaderDto_ShouldReturnReaderEntityWithCorrectPropertiesAndAddressIncluded()
        {
            var mapper = new DtoMapper();
            var readerDto = new ReaderDto()
            {
                Firstname = "Firstname1",
                Lastname = "Lastname1",
                Birthdate = new DateTime(2000, 10, 11),
                EmailAddress = "email.address@email.com",
                PhoneNumber = "+48999999999",
                Country = "Poland",
                City = "Warsaw"
            };

            var readerEntity = mapper.Map(readerDto);

            readerEntity.Should().BeOfType<ReaderEntity>();
            readerEntity.Should().BeEquivalentTo(readerDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfReaderEntities_ShouldReturnListOfReaderDtosWithCorrectPropertiesAndAddressesIncluded()
        {
            var mapper = new DtoMapper();
            var addressEntity = new AddressEntity()
            {
                Id = new Guid(),
                Country = "Poland",
                City = "Warsaw"
            };
            var readerEntities = new List<ReaderEntity>()
            {
                new ReaderEntity(){Id = new Guid(), Firstname = "Firstname 1", Lastname = "Lastname 1", Address = addressEntity, AddressId = addressEntity.Id},
                new ReaderEntity(){Id = new Guid(), Firstname = "Firstname 2", Lastname = "Lastname 2", Address = addressEntity, AddressId = addressEntity.Id}
            };

            var readerDtos = mapper.Map(readerEntities);

            readerDtos.Should().BeOfType<List<ReaderDto>>();
            readerDtos.Should().BeEquivalentTo(readerEntities, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfReaderDtos_ShouldReturnListOfReaderEntitiesWithCorrectPropertiesAndAddressesIncluded()
        {
            var mapper = new DtoMapper();
            var readerDtos = new List<ReaderDto>()
            {
                new ReaderDto(){Firstname = "Firstname 1", Lastname = "Lastname 1", Country = "Poland"},
                new ReaderDto(){Firstname = "Firstname 2", Lastname = "Lastname 2", Country = "Poland"}
            };

            var readerEntities = mapper.Map(readerDtos);

            readerEntities.Should().BeOfType<List<ReaderEntity>>();
            readerEntities.Should().BeEquivalentTo(readerDtos, options => options.ExcludingMissingMembers());
        }
    }
}
