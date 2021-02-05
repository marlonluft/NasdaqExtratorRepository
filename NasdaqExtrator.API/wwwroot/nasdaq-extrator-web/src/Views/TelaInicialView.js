import React, { Component } from 'react'
import { connect } from 'react-redux'

/* Actions */
import { handleTopDividendoPagosAnoCorrente, handleTopPagadorasDividendosEstaveis, handleTopStocksCrescentes } from '../Actions/ConsolidadoAction'

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

                <table border="1">
                    <thead>
                        <tr>
                            <th colSpan={4}>Top 10 Dividendos Pagos 2020</th>
                        </tr>
                        <tr>
                            <th>Simbolo</th>
                            <th>Valor Médio Pago</th>
                            <th>Valor Total Pago</th>
                            <th>Qtd Dividendos Pagos</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            consolidado.TopDividendoPagosAnoCorrente.map((registro) => {
                                return <tr key={registro.simbolo}>
                                    <td>{registro.simbolo}</td>
                                    <td>$ {registro.valorMedioPago}</td>
                                    <td>$ {registro.valorTotalPago}</td>
                                    <td>{registro.quantidadePaga}</td>
                                </tr>
                            })
                        }
                    </tbody>
                </table>

<br/>

                <table border="1">
                    <thead>
                        <tr>
                            <th colSpan={2+consolidado.TopPagadorasDividendosEstaveis[0].anos.length}>Top 10 Pagadoras Dividendos Estáveis</th>
                        </tr>
                        <tr>
                            <th>Simbolo</th>
                            {
                                consolidado.TopPagadorasDividendosEstaveis[0].anos.map((ano) => {
                                    return <th>V.M. {ano.ano}</th>
                                })
                            }
                            <th>Qtd Média Dividendos Pagos</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            consolidado.TopPagadorasDividendosEstaveis.map((registro) => {
                                return <tr key={registro.simbolo}>
                                    <td>{registro.simbolo}</td>
                                    {
                                        registro.anos.map((ano) => {
                                            return <td>$ {ano.valorMedioDividendo}</td>
                                        })
                                    }
                                    <td>{registro.quantidadeMediaDividendosPagos}</td>
                                </tr>
                            })
                        }
                    </tbody>
                </table>

                <br/>

                <table border="1">
                    <thead>
                        <tr>
                            <th colSpan={1+consolidado.TopStocksCrescentes[0].anos.length}>Top 10 Stock Crescentes</th>
                        </tr>
                        <tr>
                            <th>Simbolo</th>
                            {
                                consolidado.TopStocksCrescentes[0].anos.map((ano) => {
                                    return <th>Cresc. {ano.ano}</th>
                                })
                            }
                        </tr>
                    </thead>
                    <tbody>
                        {
                            consolidado.TopStocksCrescentes.map((registro) => {
                                return <tr key={registro.simbolo}>
                                    <td>{registro.simbolo}</td>
                                    {
                                        registro.anos.map((ano) => {
                                            return <td>{ano.porcentagem}%</td>
                                        })
                                    }
                                </tr>
                            })
                        }
                    </tbody>
                </table>

            </div>
        )
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        onLoad: () => {
            dispatch(handleTopDividendoPagosAnoCorrente())
            dispatch(handleTopPagadorasDividendosEstaveis())
            dispatch(handleTopStocksCrescentes())
        }
    }
}

export default connect((state) => ({
    consolidado: state.consolidado,
}), mapDispatchToProps)
    (TelaInicialView)