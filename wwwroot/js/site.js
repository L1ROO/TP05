function validarLogin() {
        let esValido = true;

        document.getElementById("errorNombreUsuario").innerText = "";
        document.getElementById("errorContrasenia").innerText = "";

        let nombreUsuario = document.getElementById("NombreUsuario").value;
        let contrasenia = document.getElementById("Contrasenia").value;

        if (nombreUsuario === "") {
            document.getElementById("errorNombreUsuario").innerText = "Ingrese su nombre de usuario.";
            esValido = false;
        }

        if (contrasenia === "") {
            document.getElementById("errorContrasenia").innerText = "Ingrese su contraseña.";
            esValido = false;
        }

        return esValido;
    }

function validarFormulario() {
        let esValido = true;

        document.getElementById("errorNombreUsuario").innerText = "";
        document.getElementById("errorContrasenia").innerText = "";
        document.getElementById("errorNombre").innerText = "";
        document.getElementById("errorApellido").innerText = "";
        document.getElementById("errorTipoUsuario").innerText = "";

        let nombreUsuario = document.getElementById("NombreUsuario").value.trim();
        let contrasenia = document.getElementById("Contrasenia").value.trim();
        let nombre = document.getElementById("Nombre").value.trim();
        let apellido = document.getElementById("Apellido").value.trim();
        let tipoUsuario = document.getElementById("TipoUsuario").value;

        let soloLetras = /^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$/;

        if (nombreUsuario === "") {
            document.getElementById("errorNombreUsuario").innerText = "El nombre de usuario es obligatorio.";
            esValido = false;
        } else if (nombreUsuario.length < 4) {
            document.getElementById("errorNombreUsuario").innerText = "Debe tener al menos 4 caracteres.";
            esValido = false;
        }

        if (contrasenia === "") {
            document.getElementById("errorContrasenia").innerText = "La contraseña es obligatoria.";
            esValido = false;
        } else if (contrasenia.length < 6) {
            document.getElementById("errorContrasenia").innerText = "Debe tener al menos 6 caracteres.";
            esValido = false;
        }

        if (nombre === "") {
            document.getElementById("errorNombre").innerText = "El nombre es obligatorio.";
            esValido = false;
        } else if (!soloLetras.test(nombre)) {
            document.getElementById("errorNombre").innerText = "Solo se permiten letras.";
            esValido = false;
        }

        if (apellido === "") {
            document.getElementById("errorApellido").innerText = "El apellido es obligatorio.";
            esValido = false;
        } else if (!soloLetras.test(apellido)) {
            document.getElementById("errorApellido").innerText = "Solo se permiten letras.";
            esValido = false;
        }

        if (tipoUsuario === "") {
            document.getElementById("errorTipoUsuario").innerText = "Debe seleccionar un tipo de usuario.";
            esValido = false;
        }

        return esValido;
    }