
import './App.css';
import Arcticle from '../arcticle/Arcticle';
import Heazer from '../heazer/Heazer';
import Nav from '../nav/Nav';
import Power from '../power/Power';
import Footer from '../footer/Footer';
import data from '../arcticle/db.json';

function App() {
  let nav ={
    "Главная":"/index",
    "Новости":"/news",
    "Магазин":"/shop",
    "О нас":"/about",
    "Контакты":"/contacts"
  }

  let db = data;

  return (
    <div className="App">
      <Heazer title="Hello React" description="This is my first React App"/>
      <Nav navigation={nav}/>
      <Power a={2} n={8}/>
      <Arcticle db={db}/>
      <Footer/>
    </div>
  );
}

export default App;
