import { useEffect, useState } from 'react';
import GameCard from './components/GameCard';
import MyGameCard from './components/myGameCard';
import './App.css';
 
const App = () => {
    const [games, setGames] = useState([]);
    const [myGames, setMyGames] = useState([]);

    const handleAddToMyGames = (selectedGame) => {
        const isGameAlreadyAdded = myGames.some(game => game === selectedGame);

        if (!isGameAlreadyAdded) {
            setMyGames(prevMyGames => [...prevMyGames, selectedGame]);
        }
    };


    const handleRemoveFromMyGames = (selectedGame) => {
        const updatedMesJeux = myGames.filter(myGame => myGame !== selectedGame);
        setMyGames(updatedMesJeux);
    };

    useEffect(() => {
        fetch('/api/games')
            .then(response => response.json())
            .then(data => setGames(data))
            .catch(error => console.error('Erreur lors de la récupération des jeux :', error));
    }, []);


    return (

        <div className="page-container">
            <h1>My Steam</h1>
            <div className="container">
                <div className="left-section">
                    <h2>Mes jeux</h2>
                    <div className="card-container">
                        {myGames.map((selectedGame) => (
                            <MyGameCard key={selectedGame.name} game={selectedGame} removeToMyGames={handleRemoveFromMyGames} />
                        ))}
                    </div>
                </div>
                <div className="right-section">
                    <h2>Bibliotech de jeux</h2>
                    <div className="card-container">
                        {games.map(game => (
                            <GameCard key={game.name} game={game} onAddToMyGames={handleAddToMyGames} />
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default App;