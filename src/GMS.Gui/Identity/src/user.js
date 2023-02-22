// in src/users.js
import * as React from "react";
import { List, Datagrid, TextField, EmailField } from 'react-admin';

export const userlist = () => (
    <List>
        <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="userName" />
            <TextField source="telegramUserName" />
            <EmailField source="email" />
            <TextField source="isActive" />
        </Datagrid>
    </List>
);