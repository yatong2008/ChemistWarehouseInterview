import React from "react";
import styles from "./Header.module.css"
import { Layout, Typography, Menu, Button, Dropdown } from 'antd'

export const Footer: React.FC = () => {
    return (
        <Layout.Footer>
            <Typography.Title level={3} style={{textAlign: 'center'}}>
                © Copyright
            </Typography.Title>
        </Layout.Footer>
    );
};