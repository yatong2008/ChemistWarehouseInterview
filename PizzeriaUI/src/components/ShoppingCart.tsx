import React from "react";

interface Props {

}

interface State {
    isOpen: boolean
}

class ShoppingCart extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = {
            isOpen: false,
        };
    }

    render() {
        return (
            <div>
                <button>Shopping Cart 2 (items)</button>
                <div>
                    <ul>
                        <li>Pizza 1</li>
                        <li>Pizza 2</li>
                    </ul>
                </div>
            </div>
        );
    }
}

export default ShoppingCart;