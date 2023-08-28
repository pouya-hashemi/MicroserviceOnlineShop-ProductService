﻿using Microsoft.Extensions.DependencyInjection;
using OnlineShopMicroServices.ProductService.WebApi.EntityConstraints;
using OnlineShopMicroServices.ProductService.WebApi.Exceptions;
using OnlineShopMicroServices.ProductServiceTest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMicroServices.ProductServiceTest.Entities
{
    public class ProductTests
    {
        private readonly ValidEntities _validEntities;
        public ProductTests()
        {
            _validEntities = new ValidEntities();
        }
        public static IEnumerable<object[]> SetName_ShouldThrowBadRequestException_WhenInputIsNullEmptyOrHasLongOrShortLength_Data()
        {
            yield return new object[]
            {
                ""
            };

            yield return new object[]
            {
                " "
            };

            yield return new object[]
            {
                null
            };

            yield return new object[]
            {
                new string(Enumerable.Repeat('a',ProductConstraint.NameMinLength-1).ToArray())
            };

            yield return new object[]
            {
                new string(Enumerable.Repeat('a',ProductConstraint.NameMaxLength+1).ToArray())
            };
        }
        [Theory]
        [MemberData(nameof(SetName_ShouldThrowBadRequestException_WhenInputIsNullEmptyOrHasLongOrShortLength_Data))]
        public void SetName_ShouldThrowBadRequestException_WhenInputIsNullEmptyOrHasLongOrShortLength(string name)
        {
            //Arrange
            var product = _validEntities.GetValidProduct;
            //Act
            var act = () => product.SetName(name);
            //Assert
            Assert.Throws<BadRequestException>(act);
        }
        public static IEnumerable<object[]> SetName_ShouldChangeName_WhenInputIsValid_Data()
        {
            yield return new object[]
            {
                new string(Enumerable.Repeat('a',ProductConstraint.NameMinLength).ToArray())
            };

            yield return new object[]
            {
                new string(Enumerable.Repeat('a',ProductConstraint.NameMaxLength).ToArray())
            };
        }
        [Theory]
        [MemberData(nameof(SetName_ShouldChangeName_WhenInputIsValid_Data))]
        public void SetName_ShouldChangeName_WhenInputIsValid(string name)
        {
            //Arrange
            var product = _validEntities.GetValidProduct;
            //Act
            product.SetName(name);
            //Assert
            Assert.Equal(name, product.Name);
        }
        [Fact]
        public void SetName_ShouldJustChangeName_WhenInputIsValid()
        {
            //Arrange
            var product=_validEntities.GetValidProduct;
            var oldName= product.Name;
            var product2=_validEntities.GetValidProduct2;
            var newName= product2.Name;
            //Act
            product.SetName(newName);
            product.SetName(oldName);
            //Assert
            Assert.Equivalent(product, product);
        }
    }
}
