import {
    LISTAR_TopDividendoPagosAnoCorrente,
    LISTAR_TopPagadorasDividendosEstaveis,
    LISTAR_TopStocksCrescentes,
} from '../Actions/ConsolidadoAction'

const initialState = {
    TopDividendoPagosAnoCorrente: [],
    TopPagadorasDividendosEstaveis: [],
    TopStocksCrescentes: [],
}

export function consolidadoReducer(state = initialState, action) {
    switch (action.type) {
        case LISTAR_TopDividendoPagosAnoCorrente:
            return {
                ...state, 
                TopDividendoPagosAnoCorrente: action.lista
            }
        case LISTAR_TopPagadorasDividendosEstaveis:
            return {
                ...state, 
                TopPagadorasDividendosEstaveis: action.lista
            }
        case LISTAR_TopStocksCrescentes:
            return {
                ...state, 
                TopStocksCrescentes: action.lista
            }
        default:
            return state
    }
}