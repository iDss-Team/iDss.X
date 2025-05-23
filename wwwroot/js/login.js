window.loginWithFetch = async function (loginModel) {
    const response = await fetch('/api/Auth/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        credentials: 'include', // 🟢 WAJIB untuk menyimpan cookie
        body: JSON.stringify(loginModel)
    });

    return response.ok;
}