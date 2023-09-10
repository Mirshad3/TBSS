import React, { useState } from 'react';
import axios from 'axios';

function ProjectUsers() {
    const [userId, setUserId] = useState('');
    const [projectId, setProjectId] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.post('/api/project/user', { userId, projectId })
            .then((response) => {
                console.log('User added to project:', response.data);
            })
            .catch((error) => {
                console.error('Error adding user to project:', error);
            });
    };

    return (
        <div>
            <h2>Add User to Project</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>User ID:</label>
                    <input
                        type="number"
                        value={userId}
                        onChange={(e) => setUserId(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Project ID:</label>
                    <input
                        type="number"
                        value={projectId}
                        onChange={(e) => setProjectId(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Add User to Project</button>
            </form>
        </div>
    );
}

export default ProjectUsers;
