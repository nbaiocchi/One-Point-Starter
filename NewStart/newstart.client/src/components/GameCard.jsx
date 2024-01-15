import "./css/GameCard.css";
import PropTypes from "prop-types";
import { DefaultButton } from "@fluentui/react/lib/Button";
import { Card } from "@fluentui/react-cards";

const cardTokens = { childrenMargin: 10 };

const GameCard = ({ game, onAddToMyGames }) => {
  const handleAddToMyGames = () => {
    onAddToMyGames(game);
  };

  const gameImage = new URL(
    `../assets/game-${game.gameName}.jpg`,
    import.meta.url
  ).href;

  return (
    <Card tokens={cardTokens} className="card-styles">
      <Card.Section className="section-styles">
        <img src={gameImage} alt={game.gameName} />
      </Card.Section>
      <Card.Section>
        <h2>{game.gameName}</h2>
        {game.gameCategory.map((category) => (
          <p key={category}>{category}</p>
        ))}
        <p>{game.gameDescription}</p>
        <DefaultButton onClick={handleAddToMyGames}>Ajoute</DefaultButton>
      </Card.Section>
    </Card>
  );
};

GameCard.propTypes = {
  game: PropTypes.shape({
    gameName: PropTypes.string.isRequired,
    gameDescription: PropTypes.string.isRequired,
    gameCategory: PropTypes.array.isRequired,
  }).isRequired,
  onAddToMyGames: PropTypes.func.isRequired,
};

export default GameCard;
