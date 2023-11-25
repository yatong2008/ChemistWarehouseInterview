import React from "react";
import styles from "./Header.module.css"
import logo from '../../assets/images/logo.svg';
import { Layout, Typography, Menu, Button, Dropdown } from 'antd'

export const Header: React.FC = () => {
    return (
        <div className={styles['app-header']}>
            <Layout.Header className={styles['main-header']}>
            <img src={logo} className={styles['App-logo']} alt="logo" />
            <Typography.Title level={3} className={styles.title}>
                Pizzeria
            </Typography.Title>
            </Layout.Header>
        </div>
    );
};