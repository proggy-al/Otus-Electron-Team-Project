// in src/user.js
import * as React from "react";
import { List, Datagrid, TextField, EmailField, ReferenceField, EditButton, Edit,Create,SimpleForm, ReferenceInput,TextInput } from 'react-admin';

export const userlist = () => (
    <List>
        <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="userName" />
            <TextField source="telegramUserName" />
            <EmailField source="email" />
            <TextField source="isActive" />
            <EditButton />
        </Datagrid>
    </List>
);

export const userCreate = props => (
        <Create {...props}>
                <SimpleForm>
                    <TextInput source="userName"  />
                    <TextInput source="telegramUserName" />
                    <TextInput source="email" />
                    <TextInput source="password" />
                </SimpleForm>
        </Create>
    );

export const userEdit = () => (
    <Edit>
        <SimpleForm>
            <TextInput disabled source="id" />
            <TextInput source="userName"  />
            <TextInput source="telegramUserName" />
            <TextInput source="email" />
            <TextInput source="password" />
            <TextInput source="role" />
            <TextInput source="isActive" />
        </SimpleForm>
    </Edit>
);