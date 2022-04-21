using System;
using BoardLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLibrary {
    public class PlayerModel {

        public string Name { get; set; }
        public List<string> Board { get; set; }
        public int Score { get; set; }

        public PlayerModel(string name) {
            Name = name;
            Score = 0;
            Board = BoardModel.InitBoard();
        }
    }
}
