import logo from './logo.svg';
import './App.css';  
import R017_Props from './R017_Props';
import R018_PropsDatatype from './R018_PropsDatatype';
import R019_PropsBoolean from './R019_PropsBoolean';
import R020_PropsObjVal from './R020_PropsObjVal';
import R021_PropsRequired from './R021_PropsRequired';
import R022_PropsDefault from './R022_PropsDefault';
import R023_PropsNode from './R023_PropsNode';
import R024_ReactState from './R024_ReactState';
import R025_SetState from './R025_SetState';
import R026_ForceUpdate from './R026_ForceUpdate';
import R027_ComponentClass from './R027_ComponentClass';
import R028_PureComponentClass from './R028_PureComponentClass';
import R029_ShallowEqual from './R029_ShallowEqual';
import R030_FunctionComponent from './R030_FunctionComponent';
import R031_ReactHook from './R031_ReactHook';
import R032_Fragments from './R032_Fragments';
import R033_ReturnMap from './R033_ReturnMap';

function App() {
  return (
    <div>
      <h1> Start React 200! </h1> 
      {/*
      <R017_Props props_val="THIS IS PROPS"></R017_Props>
      <R018_PropsDatatype 
        String="react"
        Number={200}
        Boolean={1==1}
        Array={[0, 1, 8]}
        ObjectJson={{react:"리액트", twohundred:"200"}}
        Function={console.log("FunctionProps: function!")}></R018_PropsDatatype>
      <R019_PropsBoolean BooleanTrueFalse={false}></R019_PropsBoolean>
      <R019_PropsBoolean BooleanTrueFalse></R019_PropsBoolean>
      <R020_PropsObjVal ObjectJson={{react:"리액트", twohundred:"200"}}></R020_PropsObjVal>
      <R021_PropsRequired ReactNumber={200}></R021_PropsRequired>
      <R022_PropsDefault ReactNumber={200}></R022_PropsDefault>
      <R023_PropsNode>
        <span>node from App.js</span>
      </R023_PropsNode>
      <R024_ReactState reactString={"react"}></R024_ReactState>
      <R025_SetState></R025_SetState>
      <R026_ForceUpdate></R026_ForceUpdate>
      <R027_ComponentClass></R027_ComponentClass>
      <R028_PureComponentClass></R028_PureComponentClass>
      <R029_ShallowEqual></R029_ShallowEqual>
      <R030_FunctionComponent contents="[THIS IS FunctionComponent]"></R030_FunctionComponent>
      <R031_ReactHook></R031_ReactHook>
      <R032_Fragments></R032_Fragments>
      */} 

      <R033_ReturnMap></R033_ReturnMap>

    </div>    
  );
}

export default App;
