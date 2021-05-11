using System;
using WebApp.Data;
using Xunit;

namespace Test
{
    public class UnitTest1
    {

        private readonly PlayerService _playerService;

        public UnitTest1(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [Fact]
        public void Test1()
        {
            
        }
    }
}
