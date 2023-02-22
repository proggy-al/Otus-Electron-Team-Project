// in src/projects.js
import * as React from "react";
import { List, Datagrid, TextField,DateField } from 'react-admin';

export const projectsList = () => (
    <List>
        <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="createdBy" />
            <TextField source="createdAt" />
        </Datagrid>
    </List>
);