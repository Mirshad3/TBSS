import React, { useState } from 'react';
import axios from 'axios';

function ProjectAdd() {
    const [projectName, setProjectName] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.post('/api/project', { name: projectName })
            .then((response) => {
                console.log('Project created:', response.data);
            })
            .catch((error) => {
                console.error('Error creating project:', error);
            });
    };

    return (
        <div>
            <h2>Add Project</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Project Name:</label>
                    <input
                        type="text"
                        value={projectName}
                        onChange={(e) => setProjectName(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Add Project</button>
            </form>
        </div>
    );
}

export default ProjectAdd;
