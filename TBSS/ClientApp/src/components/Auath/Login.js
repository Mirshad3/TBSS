import React from 'react';
import { useAuth } from './AuthContext';

function Login() {
    const { login } = useAuth();

     
    const login = async (userData) => {
        try {
            const response = await axios.post('/api/auth/Login', userData);
            const token = response.data.token;

            // Store the token in local storage
            localStorage.setItem('token', token);

            // Set the token in Axios headers for future requests
            axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
 

            setMessage('Login successful!');

        } catch (error) {
            console.error('Error logging in:', error);
            throw error;
        }
    };

    return (
        <div>
            <h2>Login Page</h2>
            <form>
                <div>
                    <label htmlFor="username">Username</label>
                    <input
                        type="text"
                        id="username"
                        name="username"
                        value={formData.username}
                        onChange={handleInputChange}
                    />
                </div>
                <div>
                    <label htmlFor="password">Password</label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        value={formData.password}
                        onChange={handleInputChange}
                    />
                </div>
                <button type="button" onClick={handleLogin}>
                    Login
                </button>
            </form>
            {message && <p>{message}</p>}
        </div>
    );
}

}

export default Login;
