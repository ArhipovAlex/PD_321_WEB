
import './App.css';
import Arcticle from '../arcticle/Arcticle';
import Heazer from '../heazer/Heazer';
import Nav from '../nav/Nav';
import Power from '../power/Power';
import Switch from '../switch/Switch';
import Fact from '../fact/Fact';
import Fib from '../fib/Fib';
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
      <Switch/>
      <Power a={2} n={8}/>
      <Fact a={0}/>
      <Fib a={7}/>
      <Arcticle db={data}/>
      <Footer year="2024"/>
    </div>
  );
}

export default App;
