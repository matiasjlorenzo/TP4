namespace TP4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtCantSimulaciones = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtDesde = new TextBox();
            txtHasta = new TextBox();
            btnSimular = new Button();
            dataGridSimulacion = new DataGridView();
            colNroSimulacion = new DataGridViewTextBoxColumn();
            colEvento = new DataGridViewTextBoxColumn();
            colReloj = new DataGridViewTextBoxColumn();
            colRndLlegadaEmpleado = new DataGridViewTextBoxColumn();
            colTiempoEntreLlegadas = new DataGridViewTextBoxColumn();
            colProxLlegada = new DataGridViewTextBoxColumn();
            colADondeVoy = new DataGridViewTextBoxColumn();
            colRndFinRegistro = new DataGridViewTextBoxColumn();
            colTiempoRegistro = new DataGridViewTextBoxColumn();
            colFinRegistro = new DataGridViewTextBoxColumn();
            colRndLlegadaTecnico = new DataGridViewTextBoxColumn();
            colTiempoLlegadaTecnico = new DataGridViewTextBoxColumn();
            colTiempoDeLlegadaTecnico = new DataGridViewTextBoxColumn();
            colEstadoTecnico = new DataGridViewTextBoxColumn();
            colRndFinMantenimiento = new DataGridViewTextBoxColumn();
            colTiempoMantenimiento = new DataGridViewTextBoxColumn();
            colFinMantenimiento = new DataGridViewTextBoxColumn();
            colTerminal1 = new DataGridViewTextBoxColumn();
            colTerminal2 = new DataGridViewTextBoxColumn();
            colTerminal3 = new DataGridViewTextBoxColumn();
            colTerminal4 = new DataGridViewTextBoxColumn();
            colCola = new DataGridViewTextBoxColumn();
            colAcumuladorEmpleadosSeVan = new DataGridViewTextBoxColumn();
            colAcumuladorEmpleadosRegistrados = new DataGridViewTextBoxColumn();
            colAcumuladorTiempoEsperaEmpleados = new DataGridViewTextBoxColumn();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtMedia = new TextBox();
            txtFinRegistroA = new TextBox();
            txtFinRegistroB = new TextBox();
            txtLlegadaTecnicoA = new TextBox();
            txtLlegadaTecnicoB = new TextBox();
            txtFinMantenimientoA = new TextBox();
            txtFinMantenimientoB = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridSimulacion).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 0;
            label1.Text = "Cant de Simulaciones:";
            // 
            // txtCantSimulaciones
            // 
            txtCantSimulaciones.Location = new Point(142, 21);
            txtCantSimulaciones.Name = "txtCantSimulaciones";
            txtCantSimulaciones.Size = new Size(100, 23);
            txtCantSimulaciones.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 24);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Desde:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(268, 58);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 3;
            label3.Text = "Hasta:";
            // 
            // txtDesde
            // 
            txtDesde.Location = new Point(316, 21);
            txtDesde.Name = "txtDesde";
            txtDesde.Size = new Size(100, 23);
            txtDesde.TabIndex = 4;
            // 
            // txtHasta
            // 
            txtHasta.Location = new Point(316, 55);
            txtHasta.Name = "txtHasta";
            txtHasta.Size = new Size(100, 23);
            txtHasta.TabIndex = 5;
            // 
            // btnSimular
            // 
            btnSimular.Location = new Point(921, 76);
            btnSimular.Name = "btnSimular";
            btnSimular.Size = new Size(75, 23);
            btnSimular.TabIndex = 6;
            btnSimular.Text = "Simular";
            btnSimular.UseVisualStyleBackColor = true;
            btnSimular.Click += btnSimular_Click_1;
            // 
            // dataGridSimulacion
            // 
            dataGridSimulacion.AllowUserToAddRows = false;
            dataGridSimulacion.AllowUserToDeleteRows = false;
            dataGridSimulacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSimulacion.Columns.AddRange(new DataGridViewColumn[] { colNroSimulacion, colEvento, colReloj, colRndLlegadaEmpleado, colTiempoEntreLlegadas, colProxLlegada, colADondeVoy, colRndFinRegistro, colTiempoRegistro, colFinRegistro, colRndLlegadaTecnico, colTiempoLlegadaTecnico, colTiempoDeLlegadaTecnico, colEstadoTecnico, colRndFinMantenimiento, colTiempoMantenimiento, colFinMantenimiento, colTerminal1, colTerminal2, colTerminal3, colTerminal4, colCola, colAcumuladorEmpleadosSeVan, colAcumuladorEmpleadosRegistrados, colAcumuladorTiempoEsperaEmpleados });
            dataGridSimulacion.Location = new Point(12, 114);
            dataGridSimulacion.Name = "dataGridSimulacion";
            dataGridSimulacion.RowTemplate.Height = 25;
            dataGridSimulacion.Size = new Size(1204, 495);
            dataGridSimulacion.TabIndex = 7;
            // 
            // colNroSimulacion
            // 
            colNroSimulacion.HeaderText = "Nro Simulación";
            colNroSimulacion.Name = "colNroSimulacion";
            // 
            // colEvento
            // 
            colEvento.HeaderText = "Evento";
            colEvento.Name = "colEvento";
            // 
            // colReloj
            // 
            colReloj.HeaderText = "Reloj";
            colReloj.Name = "colReloj";
            // 
            // colRndLlegadaEmpleado
            // 
            colRndLlegadaEmpleado.HeaderText = "Rnd Llegada Empleado";
            colRndLlegadaEmpleado.Name = "colRndLlegadaEmpleado";
            // 
            // colTiempoEntreLlegadas
            // 
            colTiempoEntreLlegadas.HeaderText = "Tiempo Entre Llegadas";
            colTiempoEntreLlegadas.Name = "colTiempoEntreLlegadas";
            // 
            // colProxLlegada
            // 
            colProxLlegada.HeaderText = "Prox Llegada";
            colProxLlegada.Name = "colProxLlegada";
            // 
            // colADondeVoy
            // 
            colADondeVoy.HeaderText = "A Donde Voy";
            colADondeVoy.Name = "colADondeVoy";
            // 
            // colRndFinRegistro
            // 
            colRndFinRegistro.HeaderText = "Rnd Fin Registro";
            colRndFinRegistro.Name = "colRndFinRegistro";
            // 
            // colTiempoRegistro
            // 
            colTiempoRegistro.HeaderText = "Tiempo de Registro";
            colTiempoRegistro.Name = "colTiempoRegistro";
            // 
            // colFinRegistro
            // 
            colFinRegistro.HeaderText = "Fin Registro";
            colFinRegistro.Name = "colFinRegistro";
            // 
            // colRndLlegadaTecnico
            // 
            colRndLlegadaTecnico.HeaderText = "Rnd Llegada Técnico";
            colRndLlegadaTecnico.Name = "colRndLlegadaTecnico";
            // 
            // colTiempoLlegadaTecnico
            // 
            colTiempoLlegadaTecnico.HeaderText = "Tiempo Llegada Técnico";
            colTiempoLlegadaTecnico.Name = "colTiempoLlegadaTecnico";
            // 
            // colTiempoDeLlegadaTecnico
            // 
            colTiempoDeLlegadaTecnico.HeaderText = "Tiempo de Llegada Técnico";
            colTiempoDeLlegadaTecnico.Name = "colTiempoDeLlegadaTecnico";
            // 
            // colEstadoTecnico
            // 
            colEstadoTecnico.HeaderText = "Estado Técnico";
            colEstadoTecnico.Name = "colEstadoTecnico";
            // 
            // colRndFinMantenimiento
            // 
            colRndFinMantenimiento.HeaderText = "Rnd Fin Mantenimiento";
            colRndFinMantenimiento.Name = "colRndFinMantenimiento";
            // 
            // colTiempoMantenimiento
            // 
            colTiempoMantenimiento.HeaderText = "Tiempo Mantenimiento";
            colTiempoMantenimiento.Name = "colTiempoMantenimiento";
            // 
            // colFinMantenimiento
            // 
            colFinMantenimiento.HeaderText = "Fin Mantenimiento";
            colFinMantenimiento.Name = "colFinMantenimiento";
            // 
            // colTerminal1
            // 
            colTerminal1.HeaderText = "Terminal 1";
            colTerminal1.Name = "colTerminal1";
            // 
            // colTerminal2
            // 
            colTerminal2.HeaderText = "Terminal 2";
            colTerminal2.Name = "colTerminal2";
            // 
            // colTerminal3
            // 
            colTerminal3.HeaderText = "Terminal 3";
            colTerminal3.Name = "colTerminal3";
            // 
            // colTerminal4
            // 
            colTerminal4.HeaderText = "Terminal 4";
            colTerminal4.Name = "colTerminal4";
            // 
            // colCola
            // 
            colCola.HeaderText = "Cola";
            colCola.Name = "colCola";
            // 
            // colAcumuladorEmpleadosSeVan
            // 
            colAcumuladorEmpleadosSeVan.HeaderText = "Acumulador Empleados que se Van";
            colAcumuladorEmpleadosSeVan.Name = "colAcumuladorEmpleadosSeVan";
            // 
            // colAcumuladorEmpleadosRegistrados
            // 
            colAcumuladorEmpleadosRegistrados.HeaderText = "Acumulador Empleados Registrados";
            colAcumuladorEmpleadosRegistrados.Name = "colAcumuladorEmpleadosRegistrados";
            // 
            // colAcumuladorTiempoEsperaEmpleados
            // 
            colAcumuladorTiempoEsperaEmpleados.HeaderText = "Acumulador Tiempo Espera de Empleados";
            colAcumuladorTiempoEsperaEmpleados.Name = "colAcumuladorTiempoEsperaEmpleados";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(96, 59);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 8;
            label4.Text = "Media";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 22);
            label5.Name = "label5";
            label5.Size = new Size(15, 15);
            label5.TabIndex = 9;
            label5.Text = "A";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 57);
            label6.Name = "label6";
            label6.Size = new Size(14, 15);
            label6.TabIndex = 10;
            label6.Text = "B";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 57);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 11;
            label7.Text = "B";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 22);
            label8.Name = "label8";
            label8.Size = new Size(15, 15);
            label8.TabIndex = 12;
            label8.Text = "A";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 57);
            label9.Name = "label9";
            label9.Size = new Size(14, 15);
            label9.TabIndex = 13;
            label9.Text = "B";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 22);
            label10.Name = "label10";
            label10.Size = new Size(15, 15);
            label10.TabIndex = 14;
            label10.Text = "A";
            // 
            // txtMedia
            // 
            txtMedia.Location = new Point(142, 56);
            txtMedia.Name = "txtMedia";
            txtMedia.Size = new Size(100, 23);
            txtMedia.TabIndex = 15;
            // 
            // txtFinRegistroA
            // 
            txtFinRegistroA.Location = new Point(27, 19);
            txtFinRegistroA.Name = "txtFinRegistroA";
            txtFinRegistroA.Size = new Size(100, 23);
            txtFinRegistroA.TabIndex = 16;
            // 
            // txtFinRegistroB
            // 
            txtFinRegistroB.Location = new Point(27, 54);
            txtFinRegistroB.Name = "txtFinRegistroB";
            txtFinRegistroB.Size = new Size(100, 23);
            txtFinRegistroB.TabIndex = 17;
            // 
            // txtLlegadaTecnicoA
            // 
            txtLlegadaTecnicoA.Location = new Point(29, 19);
            txtLlegadaTecnicoA.Name = "txtLlegadaTecnicoA";
            txtLlegadaTecnicoA.Size = new Size(100, 23);
            txtLlegadaTecnicoA.TabIndex = 18;
            // 
            // txtLlegadaTecnicoB
            // 
            txtLlegadaTecnicoB.Location = new Point(29, 54);
            txtLlegadaTecnicoB.Name = "txtLlegadaTecnicoB";
            txtLlegadaTecnicoB.Size = new Size(100, 23);
            txtLlegadaTecnicoB.TabIndex = 19;
            // 
            // txtFinMantenimientoA
            // 
            txtFinMantenimientoA.Location = new Point(27, 19);
            txtFinMantenimientoA.Name = "txtFinMantenimientoA";
            txtFinMantenimientoA.Size = new Size(100, 23);
            txtFinMantenimientoA.TabIndex = 20;
            // 
            // txtFinMantenimientoB
            // 
            txtFinMantenimientoB.Location = new Point(26, 54);
            txtFinMantenimientoB.Name = "txtFinMantenimientoB";
            txtFinMantenimientoB.Size = new Size(100, 23);
            txtFinMantenimientoB.TabIndex = 21;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtFinRegistroA);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtFinRegistroB);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(431, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(146, 87);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fin Registro";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtLlegadaTecnicoA);
            groupBox2.Controls.Add(txtLlegadaTecnicoB);
            groupBox2.Location = new Point(599, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(144, 84);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Llegada Técnico";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(txtFinMantenimientoA);
            groupBox3.Controls.Add(txtFinMantenimientoB);
            groupBox3.Location = new Point(764, 15);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(142, 84);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Fin Mantenimiento";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 627);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtMedia);
            Controls.Add(label4);
            Controls.Add(dataGridSimulacion);
            Controls.Add(btnSimular);
            Controls.Add(txtHasta);
            Controls.Add(txtDesde);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtCantSimulaciones);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridSimulacion).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCantSimulaciones;
        private Label label2;
        private Label label3;
        private TextBox txtDesde;
        private TextBox txtHasta;
        private Button btnSimular;
        private DataGridView dataGridSimulacion;
        private DataGridViewTextBoxColumn colNroSimulacion;
        private DataGridViewTextBoxColumn colEvento;
        private DataGridViewTextBoxColumn colReloj;
        private DataGridViewTextBoxColumn colRndLlegadaEmpleado;
        private DataGridViewTextBoxColumn colTiempoEntreLlegadas;
        private DataGridViewTextBoxColumn colProxLlegada;
        private DataGridViewTextBoxColumn colADondeVoy;
        private DataGridViewTextBoxColumn colRndFinRegistro;
        private DataGridViewTextBoxColumn colTiempoRegistro;
        private DataGridViewTextBoxColumn colFinRegistro;
        private DataGridViewTextBoxColumn colRndLlegadaTecnico;
        private DataGridViewTextBoxColumn colTiempoLlegadaTecnico;
        private DataGridViewTextBoxColumn colTiempoDeLlegadaTecnico;
        private DataGridViewTextBoxColumn colEstadoTecnico;
        private DataGridViewTextBoxColumn colRndFinMantenimiento;
        private DataGridViewTextBoxColumn colTiempoMantenimiento;
        private DataGridViewTextBoxColumn colFinMantenimiento;
        private DataGridViewTextBoxColumn colTerminal1;
        private DataGridViewTextBoxColumn colTerminal2;
        private DataGridViewTextBoxColumn colTerminal3;
        private DataGridViewTextBoxColumn colTerminal4;
        private DataGridViewTextBoxColumn colCola;
        private DataGridViewTextBoxColumn colAcumuladorEmpleadosSeVan;
        private DataGridViewTextBoxColumn colAcumuladorEmpleadosRegistrados;
        private DataGridViewTextBoxColumn colAcumuladorTiempoEsperaEmpleados;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtMedia;
        private TextBox txtFinRegistroA;
        private TextBox txtFinRegistroB;
        private TextBox txtLlegadaTecnicoA;
        private TextBox txtLlegadaTecnicoB;
        private TextBox txtFinMantenimientoA;
        private TextBox txtFinMantenimientoB;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}