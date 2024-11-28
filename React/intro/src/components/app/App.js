
import './App.css';
import Arcticle from '../arcticle/Arcticle';
import Heazer from '../heazer/Heazer';
import Nav from '../nav/Nav';
import Power from '../power/Power';
import Footer from '../footer/Footer';

function App() {
  let nav ={
    "Главная":"/index",
    "Новости":"/news",
    "Магазин":"/shop",
    "О нас":"/about",
    "Контакты":"/contacts"
  }
  return (
    <div className="App">
      <Heazer title="Hello React" description="This is my first React App"/>
      <Nav navigation={nav}/>
      <Power a={2} n={8}/>
      <Arcticle/>
      <Arcticle/>
      <Arcticle/>
      <Footer/>
    </div>
  );
}

export default App;
