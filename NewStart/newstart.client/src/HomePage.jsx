import MyGameCard from "./components/myGameCard";
import "./css/HomePage.css";
import NavBar from "./components/NavBar";
import { useGameContext } from "./GameContext";

const HomePage = () => {
  const { myGames, setMyGames } = useGameContext();

  const handleRemoveFromMyGames = (selectedGame) => {
    const updatedMesJeux = myGames.filter((myGame) => myGame !== selectedGame);
    setMyGames(updatedMesJeux);
  };

  return (
    <div>
      <NavBar />
      <h2>Mes jeux</h2>
      <div className="card-container">
        {myGames.map((selectedGame) => (
          <MyGameCard
            key={selectedGame.gameId}
            game={selectedGame}
            removeToMyGames={handleRemoveFromMyGames}
            style={{ marginRight: "10px" }}
          />
        ))}
      </div>
    </div>
  );
};

export default HomePage;
