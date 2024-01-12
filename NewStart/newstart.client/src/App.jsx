import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './HomePage.jsx';
import BoutiquePage from './BoutiquePage.jsx';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/boutique" element={<BoutiquePage />} />
      </Routes>
    </Router>
  );
}

export default App;