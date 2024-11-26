import logo from './logo.svg';
import './App.css';
import Arcticle from './arcticle/Arcticle'

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h1>Hello React</h1>
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a> 
      </header>
      <Arcticle/>
      <Arcticle/>
      <Arcticle/>
      <Arcticle/>
      <Arcticle/>
      <Arcticle/>
      <Arcticle/>
    </div>
  );
}

export default App;
