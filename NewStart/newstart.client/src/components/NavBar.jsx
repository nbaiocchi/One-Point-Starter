import { Stack, DefaultButton } from '@fluentui/react';
import './css/NavBar.css';
import { useNavigate } from 'react-router-dom';


const stackTokens = { childrenGap: 20 };

const NavBar = () => {

    const navigate = useNavigate();

    const goToMyGamesClick = () => {
        navigate('/');
    };

    const goToBoutiqueClick = () => {
        navigate('/boutique');
    };

    return (
        <Stack horizontal tokens={stackTokens} horizontalAlign="space-between" className="navBarContainer">
            <span className="navBarTitle">My Steam</span>
            <Stack horizontal tokens={stackTokens} className="buttonStack">
                <DefaultButton text="Mes jeux" onClick={goToMyGamesClick} />
                <DefaultButton text="Magasin" onClick={goToBoutiqueClick} />
            </Stack>
        </Stack>
    );
};

export default NavBar;
