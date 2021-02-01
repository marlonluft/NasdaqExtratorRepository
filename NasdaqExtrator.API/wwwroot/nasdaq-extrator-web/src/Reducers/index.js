import { combineReducers } from 'redux'

import { consolidadoReducer } from './ConsolidadoReducer'

export default combineReducers({
    consolidado: consolidadoReducer,
})