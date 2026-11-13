import { render } from 'preact'
import './styles/global.css'
import Router from "./router/Router.jsx";
import "./libs/webviewBridge.js"

render(<Router />, document.getElementById('app'))
