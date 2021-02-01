import {
    LISTAR_TopDividendoPagosAnoCorrente,
    LISTAR_TopPagadorasDividendosEstaveis,
    LISTAR_TopStocksCrescentes,
} from '../Actions/ConsolidadoAction'

export function DividendoPagosAnoCorrente(state = [], action) {
    switch (action.type) {
        case LISTAR_TopDividendoPagosAnoCorrente:
            return action.lista
        default:
            return state
    }
}

export function PagadorasDividendosEstaveis(state = [], action) {
    switch (action.type) {
        case LISTAR_TopPagadorasDividendosEstaveis:
            return action.lista
        default:
            return state
    }
}

export function StocksCrescentes(state = [], action) {
    switch (action.type) {
        case LISTAR_TopStocksCrescentes:
            return action.lista
        default:
            return state
    }
}