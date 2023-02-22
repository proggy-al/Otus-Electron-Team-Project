// import logo from './logo.svg';
// import './App.css';
//
// function App() {
//   return (
//     <div className="App">
//       <header className="App-header">
//         <img src={logo} className="App-logo" alt="logo" />
//         <p>
//           Edit <code>src/App.js</code> and save to reload.
//         </p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Learn React
//         </a>
//       </header>
//     </div>
//   );
// }

// in src/App.js
import * as React from "react";
//import { Admin } from 'react-admin';
import { Admin, Resource, ListGuesser, combineDataProviders, EditGuesser } from 'react-admin';
import jsonServerProvider from 'ra-data-json-server';
import myDataProvider from './dataProvider';
import authProvider from './authProvider';
import Dashboard from './Dashboard';
import {userlist, userEdit, userCreate} from './users';
//import {projectsList} from './projects';
import { MyLayout } from './MyLayout';

//const dataProvider = jsonServerProvider('https://localhost:7250');   //https://localhost:7250/
const dataProviderIdentity = myDataProvider('https://localhost:7118');
//const dataProviderCore =  myDataProvider('https://localhost:7044');

const dataProvider = combineDataProviders((resource) => {
    switch (resource) {
        //case 'issues':
        //case 'projects':
        //    return dataProviderCore;
        case 'user':
            return dataProviderIdentity;
        default:
            throw new Error(`Unknown resource: ${resource}`);
    }
});

//const App = () => <Admin dataProvider={dataProvider} />;<Admin  authProvider={authProvider}  dataProvider={dataProvider}>
const App = () => (
        <Admin  authProvider={authProvider}  dataProvider={dataProvider} dashboard={Dashboard} layout={MyLayout}>

            <Resource name="user" list={userlist} edit={userEdit} create={userCreate} />
            
        </Admin>
    );

//<Resource name="projects" list={projectsList}/>
export default App;
