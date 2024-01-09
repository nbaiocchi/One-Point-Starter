import './GameCard.css';
import PropTypes from 'prop-types';
import { DefaultButton } from '@fluentui/react/lib/Button';


const MyGameCard = ({ game, removeToMyGames }) => {

    const handleRemoveFromMyGames = () => {
        removeToMyGames(game);
    };

    const gameImage = new URL(`../assets/game-${game.name}.jpg`, import.meta.url).href;


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
