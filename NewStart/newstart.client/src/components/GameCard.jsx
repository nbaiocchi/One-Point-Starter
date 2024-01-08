import './GameCard.css'; // Crée un fichier de style séparé si nécessaire
import PropTypes from 'prop-types';
import gameImage from '../assets/game-Zelda.jpg';
import { DefaultButton } from '@fluentui/react/lib/Button';


const GameCard = ({ game, onAddToMyGames }) => {

    const handleAddToMyGames = () => {
        onAddToMyGames(game);
    };

/*    const gameImage = import(`../assets/game-${game.name}.jpg`).then(module => module.default);
*/
    return (
        <div className="game-card">
            <img src={gameImage} alt={game.name} />
            <h3>{game.name}</h3>
            <p>{game.description}</p>
            <p>{game.category}</p>
            <DefaultButton onClick={handleAddToMyGames}>Ajoute</DefaultButton>
        </div>
    );
};

GameCard.propTypes = {
    game: PropTypes.shape({
        name: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        category: PropTypes.string.isRequired,
    }).isRequired,
    onAddToMyGames: PropTypes.func.isRequired,
};

export default GameCard;
