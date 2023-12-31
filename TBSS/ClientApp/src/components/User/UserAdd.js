﻿import React, { useState } from 'react';
import axios from 'axios';

function UserAdd() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.post('/api/user', { username, password })
            .then((response) => {
                console.log('User created:', response.data);
            })
            .catch((error) => {
                console.error('Error creating user:', error);
            });
    };

    return (
        <div>
            <h2>Add User</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Username:</label>
                    <input
                        type="text"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Password:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Add User</button>
            </form>
        </div>
    );
}

export default UserAdd;
