import logo from './logo.svg';
import './App.css';
import ImportComponent from './R003_ImportComponent';
//import LifecycleEx from './R004_LifecycleEx';
//import LifecycleEx from './R005_LifecycleEx';
//import LifecycleEx from './R006_LifecycleEx';
//import LifecycleEx from './R007_LifecycleEx';
import LifecycleEx from './R008_LifecycleEx';

function App() {
  return (
    <div>
      <h1> Start React 200! </h1>
      <p> CSS 적용하기 </p>
      <ImportComponent></ImportComponent>
      <LifecycleEx
        prop_value='From "App.js"'></LifecycleEx>
    </div>    
  );
}


export default App;
