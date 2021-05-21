import React, { Component } from 'react'
import { connect } from 'react-redux'

/* Actions */
import { handleListarStocks } from '../Actions/StockAction'

class TelaInicialView extends Component {

    componentDidMount() {
        this.props.onLoad()
    }

    render() {

        if (typeof this.props.consolidado === 'undefined') {
            return ('Falha ao carregar a página, favor tentar novamente.');
        }

        const { consolidado } = this.props

        return (
            <div>
                <h2>Bem vindo</h2>

                {
                    stocks.length > 0 ?
                        <table border="1">
                            <thead>
                                <tr>
                                    <th colSpan={4}>Stocks</th>
                                </tr>
                                <tr>
                                    <th>Simbolo</th>
                                    <th>Nome</th>
                                    <th>Preço médio atual</th>
                                    <th>Valor Dividendos Médio atual</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    consolidado.TopDividendoPagosAnoCorrente.map((registro) => {
                                        return <tr key={registro.symbol}>
                                            <td>{registro.symbol}</td>
                                            <td>{registro.name}</td>
                                            <td>$ {registro.priceCurrentAverage}</td>
                                            <td>$ {registro.dividendsCurrentAverage}</td>
                                        </tr>
                                    })
                                }
                            </tbody>
                        </table>
                        :
                        <p>Nenhum registro cadastrado</p>
                }

            </div>
        )
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        onLoad: () => {
            dispatch(handleListarStocks())
        }
    }
}

export default connect((state) => ({
    stocks: state.stocks,
}), mapDispatchToProps)
    (TelaInicialView)