using System;
using Xunit;
using HashTableForStudents;
using System.Collections.Generic;

namespace HashChainTests
{
    public class HashChainTests
    {
        [Fact]
        public void UpnoInitializationCountIsZero()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            Assert.Equal(0, table.Count);
        }

        [Fact]
        public void AfterItemAdditionCountWasIncreased()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            table.Add(0, 0);
            table.Add(61, 61);
            Assert.Equal(2, table.Count);
        }

        [Fact]
        public void SingleItemWasAdded()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            table.Add(5, 5);
            Assert.True(table.ContainsKey(5));
        }

        [Fact]
        public void ChainContainsItems()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            int[] elements = { 0, 61, 122};
            foreach (var element in elements)
            {
                table.Add(element, element);
            }
            foreach (var element in elements)
            {
                Assert.True(table.ContainsKey(element));
            }
        }

        [Fact]
        public void AfterIncreaseTableElementsDontGetRemoved()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            int[] elements = { 0, 61, 122, 183, 244, 305, 366, 427, 488, 549 };
            foreach (var element in elements)
            {
                table.Add(element, element);
            }
            foreach (var element in elements)
            {
                Assert.True(table.ContainsKey(element));
            }
        }

        [Fact]
        public void ElementWasRemoved()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            int[] elements = { 0, 61, 122, 183, 244};
            foreach (var element in elements)
            {
                table.Add(element, element);
            }
            table.Remove(elements[1]);
            Assert.False(table.ContainsKey(elements[1]));
        }

        [Fact]
        public void RemoveDecreasesCount()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            int[] elements = { 0, 61, 122, 183, 244 };
            foreach (var element in elements)
            {
                table.Add(element, element);
            }
            for (int i = 0; i < 2; i++)
            {
                table.Remove(elements[i]);
            }
            Assert.Equal(3, table.Count);
        }

        [Fact]
        public void ArgumentExceptionWhenRemoveNonexistingElement()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            int[] elements = { 0, 61, 122, 183, 244 };
            foreach (var element in elements)
            {
                table.Add(element, element);
            }
            Assert.Throws<KeyNotFoundException>(() => table.Remove(1));
        }

        [Fact]
        public void IndexatorReturnsExistingElement()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            int[] elements = { 0, 61, 122, 183, 244 };
            foreach (var element in elements)
            {
                table.Add(element, element);
            }
            Assert.Equal(61, table[61]);
        }

        [Fact]
        public void IndexatorThrowsExceptionWhenElementsDoesNotExist()
        {
            ChainHashTable<int, int> table = new ChainHashTable<int, int>();
            int[] elements = { 0, 61, 122, 183, 244 };
            foreach (var element in elements)
            {
                table.Add(element, element);
            }
            Assert.Throws<KeyNotFoundException>(() => table[1] = 1);
        }
    }
}
