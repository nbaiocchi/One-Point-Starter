import './GameCard.css';
import PropTypes from 'prop-types';
import gameImage from '../assets/game-Zelda.jpg';
import { DefaultButton } from '@fluentui/react/lib/Button';


const MyGameCard = ({ game, removeToMyGames }) => {

    const handleRemoveFromMyGames = () => {
        removeToMyGames(game);
    };


    return (
        <div className="game-card">
            <img src={gameImage} alt={game.name} />
            <h3>{game.name}</h3>
            <p>{game.description}</p>
            <p>{game.category}</p>
            <DefaultButton onClick={handleRemoveFromMyGames}>Suprimer</DefaultButton>
        </div>
    );
};

MyGameCard.propTypes = {
    game: PropTypes.shape({
        name: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        category: PropTypes.string.isRequired,
    }).isRequired,
    removeToMyGames: PropTypes.func.isRequired,
};

export default MyGameCard;
