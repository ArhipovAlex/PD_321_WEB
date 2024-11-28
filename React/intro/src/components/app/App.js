
import './App.css';
import Arcticle from '../arcticle/Arcticle';
import Heazer from '../heazer/Heazer';
import Footer from '../footer/Footer';
import Power from '../power/Power';

function App() {
  return (
    <div className="App">
      <Heazer title="Hello React" description="This is my first React App"/>
      <Power a={2} n={8}/>
      <Arcticle/>
      <Arcticle/>
      <Arcticle/>
      <Footer/>
    </div>
  );
}

export default App;
