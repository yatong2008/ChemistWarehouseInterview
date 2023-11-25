import { Link, Route, Routes } from "react-router-dom";
import styles from './App.module.css';
import { Header } from './components/header/Header';
import { Footer } from './components/footer/Footer';
import { HomePage } from './pages/HomePage';
import { MenuPage } from './pages/MenuPage';
import { useNavigate } from "react-router-dom";

const App: React.FC = (props) => {

  return (
    <div className={styles.App}>
      <Header />
      <div className={styles['page-content']}>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/pizzerias/:id" element={<MenuPage />} />
        </Routes>
      </div>
      <Footer />
    </div>
  );
}

export default App;
