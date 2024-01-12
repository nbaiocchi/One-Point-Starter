import React, { createContext, useContext, useState } from "react";

const GameContext = createContext();

export const useGameContext = () => {
  return useContext(GameContext);
};

export const GameProvider = ({ children }) => {
  const [myGames, setMyGames] = useState([]);

  return (
    <GameContext.Provider value={{ myGames, setMyGames }}>
      {children}
    </GameContext.Provider>
  );
};
