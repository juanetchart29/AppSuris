import React from 'react'

export function OrderSummary({ handleSubmitOrder }) {
    return (
        <div className="d-flex justify-content-end">
            <button
                onClick={handleSubmitOrder}
                className="btn btn-primary"
            >
                Generar Pedido
            </button>
        </div>
    )
}