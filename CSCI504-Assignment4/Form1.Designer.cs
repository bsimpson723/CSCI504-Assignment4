﻿namespace CSCI504_Assignment4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentlyOpenedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.Custom = new System.Windows.Forms.Panel();
            this.ColorGroup = new System.Windows.Forms.GroupBox();
            this.Silver = new System.Windows.Forms.Panel();
            this.White = new System.Windows.Forms.Panel();
            this.Red = new System.Windows.Forms.Panel();
            this.Yellow = new System.Windows.Forms.Panel();
            this.Lime = new System.Windows.Forms.Panel();
            this.Aqua = new System.Windows.Forms.Panel();
            this.Blue = new System.Windows.Forms.Panel();
            this.Fuchsia = new System.Windows.Forms.Panel();
            this.LemonChiffon = new System.Windows.Forms.Panel();
            this.SpringGreen = new System.Windows.Forms.Panel();
            this.PowderBlue = new System.Windows.Forms.Panel();
            this.MediumSlateBlue = new System.Windows.Forms.Panel();
            this.DeepPink = new System.Windows.Forms.Panel();
            this.SandyBrown = new System.Windows.Forms.Panel();
            this.Sienna = new System.Windows.Forms.Panel();
            this.BlueViolet = new System.Windows.Forms.Panel();
            this.SteelBlue = new System.Windows.Forms.Panel();
            this.DeepSkyBlue = new System.Windows.Forms.Panel();
            this.DarkSlateGray = new System.Windows.Forms.Panel();
            this.DarkKhaki = new System.Windows.Forms.Panel();
            this.Purple = new System.Windows.Forms.Panel();
            this.Navy = new System.Windows.Forms.Panel();
            this.Teal = new System.Windows.Forms.Panel();
            this.Green = new System.Windows.Forms.Panel();
            this.Olive = new System.Windows.Forms.Panel();
            this.Maroon = new System.Windows.Forms.Panel();
            this.Gray = new System.Windows.Forms.Panel();
            this.Black = new System.Windows.Forms.Panel();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.SelectedColor = new System.Windows.Forms.Panel();
            this.SelectedColorLabel = new System.Windows.Forms.Label();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.ColorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.recentlyOpenedToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // recentlyOpenedToolStripMenuItem
            // 
            this.recentlyOpenedToolStripMenuItem.Name = "recentlyOpenedToolStripMenuItem";
            this.recentlyOpenedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recentlyOpenedToolStripMenuItem.Text = "Recently opened,,,";
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawPanel.Location = new System.Drawing.Point(12, 116);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(1010, 581);
            this.DrawPanel.TabIndex = 1;
            this.DrawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.DrawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.DrawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // Custom
            // 
            this.Custom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Custom.Location = new System.Drawing.Point(371, 19);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(46, 46);
            this.Custom.TabIndex = 30;
            this.Custom.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Custom.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // ColorGroup
            // 
            this.ColorGroup.Controls.Add(this.Silver);
            this.ColorGroup.Controls.Add(this.White);
            this.ColorGroup.Controls.Add(this.Red);
            this.ColorGroup.Controls.Add(this.Yellow);
            this.ColorGroup.Controls.Add(this.Lime);
            this.ColorGroup.Controls.Add(this.Aqua);
            this.ColorGroup.Controls.Add(this.Blue);
            this.ColorGroup.Controls.Add(this.Fuchsia);
            this.ColorGroup.Controls.Add(this.LemonChiffon);
            this.ColorGroup.Controls.Add(this.SpringGreen);
            this.ColorGroup.Controls.Add(this.PowderBlue);
            this.ColorGroup.Controls.Add(this.MediumSlateBlue);
            this.ColorGroup.Controls.Add(this.DeepPink);
            this.ColorGroup.Controls.Add(this.SandyBrown);
            this.ColorGroup.Controls.Add(this.Sienna);
            this.ColorGroup.Controls.Add(this.BlueViolet);
            this.ColorGroup.Controls.Add(this.SteelBlue);
            this.ColorGroup.Controls.Add(this.DeepSkyBlue);
            this.ColorGroup.Controls.Add(this.DarkSlateGray);
            this.ColorGroup.Controls.Add(this.DarkKhaki);
            this.ColorGroup.Controls.Add(this.Purple);
            this.ColorGroup.Controls.Add(this.Navy);
            this.ColorGroup.Controls.Add(this.Teal);
            this.ColorGroup.Controls.Add(this.Green);
            this.ColorGroup.Controls.Add(this.Olive);
            this.ColorGroup.Controls.Add(this.Maroon);
            this.ColorGroup.Controls.Add(this.Gray);
            this.ColorGroup.Controls.Add(this.Black);
            this.ColorGroup.Controls.Add(this.Custom);
            this.ColorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorGroup.Location = new System.Drawing.Point(595, 33);
            this.ColorGroup.Name = "ColorGroup";
            this.ColorGroup.Size = new System.Drawing.Size(427, 77);
            this.ColorGroup.TabIndex = 0;
            this.ColorGroup.TabStop = false;
            this.ColorGroup.Text = "Color";
            // 
            // Silver
            // 
            this.Silver.BackColor = System.Drawing.Color.Silver;
            this.Silver.Location = new System.Drawing.Point(36, 45);
            this.Silver.Name = "Silver";
            this.Silver.Size = new System.Drawing.Size(20, 20);
            this.Silver.TabIndex = 13;
            this.Silver.Click += new System.EventHandler(this.ColorClick);
            this.Silver.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Silver.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // White
            // 
            this.White.BackColor = System.Drawing.Color.White;
            this.White.Location = new System.Drawing.Point(10, 45);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(20, 20);
            this.White.TabIndex = 12;
            this.White.Click += new System.EventHandler(this.ColorClick);
            this.White.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.White.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.Red;
            this.Red.Location = new System.Drawing.Point(62, 45);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(20, 20);
            this.Red.TabIndex = 12;
            this.Red.Click += new System.EventHandler(this.ColorClick);
            this.Red.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Red.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Yellow
            // 
            this.Yellow.BackColor = System.Drawing.Color.Yellow;
            this.Yellow.Location = new System.Drawing.Point(86, 45);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(20, 20);
            this.Yellow.TabIndex = 12;
            this.Yellow.Click += new System.EventHandler(this.ColorClick);
            this.Yellow.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Yellow.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Lime
            // 
            this.Lime.BackColor = System.Drawing.Color.Lime;
            this.Lime.Location = new System.Drawing.Point(111, 45);
            this.Lime.Name = "Lime";
            this.Lime.Size = new System.Drawing.Size(20, 20);
            this.Lime.TabIndex = 12;
            this.Lime.Click += new System.EventHandler(this.ColorClick);
            this.Lime.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Lime.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Aqua
            // 
            this.Aqua.BackColor = System.Drawing.Color.Aqua;
            this.Aqua.Location = new System.Drawing.Point(137, 45);
            this.Aqua.Name = "Aqua";
            this.Aqua.Size = new System.Drawing.Size(20, 20);
            this.Aqua.TabIndex = 11;
            this.Aqua.Click += new System.EventHandler(this.ColorClick);
            this.Aqua.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Aqua.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Blue
            // 
            this.Blue.BackColor = System.Drawing.Color.Blue;
            this.Blue.Location = new System.Drawing.Point(163, 45);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(20, 20);
            this.Blue.TabIndex = 11;
            this.Blue.Click += new System.EventHandler(this.ColorClick);
            this.Blue.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Blue.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Fuchsia
            // 
            this.Fuchsia.BackColor = System.Drawing.Color.Fuchsia;
            this.Fuchsia.Location = new System.Drawing.Point(189, 45);
            this.Fuchsia.Name = "Fuchsia";
            this.Fuchsia.Size = new System.Drawing.Size(20, 20);
            this.Fuchsia.TabIndex = 11;
            this.Fuchsia.Click += new System.EventHandler(this.ColorClick);
            this.Fuchsia.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Fuchsia.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // LemonChiffon
            // 
            this.LemonChiffon.BackColor = System.Drawing.Color.LemonChiffon;
            this.LemonChiffon.Location = new System.Drawing.Point(215, 45);
            this.LemonChiffon.Name = "LemonChiffon";
            this.LemonChiffon.Size = new System.Drawing.Size(20, 20);
            this.LemonChiffon.TabIndex = 11;
            this.LemonChiffon.Click += new System.EventHandler(this.ColorClick);
            this.LemonChiffon.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.LemonChiffon.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // SpringGreen
            // 
            this.SpringGreen.BackColor = System.Drawing.Color.SpringGreen;
            this.SpringGreen.Location = new System.Drawing.Point(241, 45);
            this.SpringGreen.Name = "SpringGreen";
            this.SpringGreen.Size = new System.Drawing.Size(20, 20);
            this.SpringGreen.TabIndex = 11;
            this.SpringGreen.Click += new System.EventHandler(this.ColorClick);
            this.SpringGreen.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.SpringGreen.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // PowderBlue
            // 
            this.PowderBlue.BackColor = System.Drawing.Color.PowderBlue;
            this.PowderBlue.Location = new System.Drawing.Point(267, 45);
            this.PowderBlue.Name = "PowderBlue";
            this.PowderBlue.Size = new System.Drawing.Size(20, 20);
            this.PowderBlue.TabIndex = 11;
            this.PowderBlue.Click += new System.EventHandler(this.ColorClick);
            this.PowderBlue.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.PowderBlue.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // MediumSlateBlue
            // 
            this.MediumSlateBlue.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.MediumSlateBlue.Location = new System.Drawing.Point(293, 45);
            this.MediumSlateBlue.Name = "MediumSlateBlue";
            this.MediumSlateBlue.Size = new System.Drawing.Size(20, 20);
            this.MediumSlateBlue.TabIndex = 11;
            this.MediumSlateBlue.Click += new System.EventHandler(this.ColorClick);
            this.MediumSlateBlue.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.MediumSlateBlue.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // DeepPink
            // 
            this.DeepPink.BackColor = System.Drawing.Color.DeepPink;
            this.DeepPink.Location = new System.Drawing.Point(319, 45);
            this.DeepPink.Name = "DeepPink";
            this.DeepPink.Size = new System.Drawing.Size(20, 20);
            this.DeepPink.TabIndex = 11;
            this.DeepPink.Click += new System.EventHandler(this.ColorClick);
            this.DeepPink.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.DeepPink.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // SandyBrown
            // 
            this.SandyBrown.BackColor = System.Drawing.Color.SandyBrown;
            this.SandyBrown.Location = new System.Drawing.Point(345, 45);
            this.SandyBrown.Name = "SandyBrown";
            this.SandyBrown.Size = new System.Drawing.Size(20, 20);
            this.SandyBrown.TabIndex = 11;
            this.SandyBrown.Click += new System.EventHandler(this.ColorClick);
            this.SandyBrown.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.SandyBrown.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Sienna
            // 
            this.Sienna.BackColor = System.Drawing.Color.Sienna;
            this.Sienna.Location = new System.Drawing.Point(345, 20);
            this.Sienna.Name = "Sienna";
            this.Sienna.Size = new System.Drawing.Size(20, 20);
            this.Sienna.TabIndex = 11;
            this.Sienna.Click += new System.EventHandler(this.ColorClick);
            this.Sienna.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Sienna.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // BlueViolet
            // 
            this.BlueViolet.BackColor = System.Drawing.Color.BlueViolet;
            this.BlueViolet.Location = new System.Drawing.Point(319, 20);
            this.BlueViolet.Name = "BlueViolet";
            this.BlueViolet.Size = new System.Drawing.Size(20, 20);
            this.BlueViolet.TabIndex = 11;
            this.BlueViolet.Click += new System.EventHandler(this.ColorClick);
            this.BlueViolet.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.BlueViolet.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // SteelBlue
            // 
            this.SteelBlue.BackColor = System.Drawing.Color.SteelBlue;
            this.SteelBlue.Location = new System.Drawing.Point(293, 20);
            this.SteelBlue.Name = "SteelBlue";
            this.SteelBlue.Size = new System.Drawing.Size(20, 20);
            this.SteelBlue.TabIndex = 11;
            this.SteelBlue.Click += new System.EventHandler(this.ColorClick);
            this.SteelBlue.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.SteelBlue.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // DeepSkyBlue
            // 
            this.DeepSkyBlue.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.DeepSkyBlue.Location = new System.Drawing.Point(267, 20);
            this.DeepSkyBlue.Name = "DeepSkyBlue";
            this.DeepSkyBlue.Size = new System.Drawing.Size(20, 20);
            this.DeepSkyBlue.TabIndex = 10;
            this.DeepSkyBlue.Click += new System.EventHandler(this.ColorClick);
            this.DeepSkyBlue.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.DeepSkyBlue.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // DarkSlateGray
            // 
            this.DarkSlateGray.BackColor = System.Drawing.Color.DarkSlateGray;
            this.DarkSlateGray.Location = new System.Drawing.Point(241, 20);
            this.DarkSlateGray.Name = "DarkSlateGray";
            this.DarkSlateGray.Size = new System.Drawing.Size(20, 20);
            this.DarkSlateGray.TabIndex = 9;
            this.DarkSlateGray.Click += new System.EventHandler(this.ColorClick);
            this.DarkSlateGray.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.DarkSlateGray.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // DarkKhaki
            // 
            this.DarkKhaki.BackColor = System.Drawing.Color.DarkKhaki;
            this.DarkKhaki.Location = new System.Drawing.Point(215, 20);
            this.DarkKhaki.Name = "DarkKhaki";
            this.DarkKhaki.Size = new System.Drawing.Size(20, 20);
            this.DarkKhaki.TabIndex = 8;
            this.DarkKhaki.Click += new System.EventHandler(this.ColorClick);
            this.DarkKhaki.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.DarkKhaki.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Purple
            // 
            this.Purple.BackColor = System.Drawing.Color.Purple;
            this.Purple.Location = new System.Drawing.Point(189, 20);
            this.Purple.Name = "Purple";
            this.Purple.Size = new System.Drawing.Size(20, 20);
            this.Purple.TabIndex = 7;
            this.Purple.Click += new System.EventHandler(this.ColorClick);
            this.Purple.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Purple.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Navy
            // 
            this.Navy.BackColor = System.Drawing.Color.Navy;
            this.Navy.Location = new System.Drawing.Point(163, 20);
            this.Navy.Name = "Navy";
            this.Navy.Size = new System.Drawing.Size(20, 20);
            this.Navy.TabIndex = 6;
            this.Navy.Click += new System.EventHandler(this.ColorClick);
            this.Navy.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Navy.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Teal
            // 
            this.Teal.BackColor = System.Drawing.Color.Teal;
            this.Teal.Location = new System.Drawing.Point(137, 20);
            this.Teal.Name = "Teal";
            this.Teal.Size = new System.Drawing.Size(20, 20);
            this.Teal.TabIndex = 5;
            this.Teal.Click += new System.EventHandler(this.ColorClick);
            this.Teal.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Teal.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Green
            // 
            this.Green.BackColor = System.Drawing.Color.Green;
            this.Green.Location = new System.Drawing.Point(111, 20);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(20, 20);
            this.Green.TabIndex = 4;
            this.Green.Click += new System.EventHandler(this.ColorClick);
            this.Green.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Green.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Olive
            // 
            this.Olive.BackColor = System.Drawing.Color.Olive;
            this.Olive.Location = new System.Drawing.Point(86, 20);
            this.Olive.Name = "Olive";
            this.Olive.Size = new System.Drawing.Size(20, 20);
            this.Olive.TabIndex = 3;
            this.Olive.Click += new System.EventHandler(this.ColorClick);
            this.Olive.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Olive.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Maroon
            // 
            this.Maroon.BackColor = System.Drawing.Color.Maroon;
            this.Maroon.Location = new System.Drawing.Point(62, 20);
            this.Maroon.Name = "Maroon";
            this.Maroon.Size = new System.Drawing.Size(20, 20);
            this.Maroon.TabIndex = 2;
            this.Maroon.Click += new System.EventHandler(this.ColorClick);
            this.Maroon.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Maroon.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Gray
            // 
            this.Gray.BackColor = System.Drawing.Color.Gray;
            this.Gray.Location = new System.Drawing.Point(36, 20);
            this.Gray.Name = "Gray";
            this.Gray.Size = new System.Drawing.Size(20, 20);
            this.Gray.TabIndex = 1;
            this.Gray.Click += new System.EventHandler(this.ColorClick);
            this.Gray.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Gray.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // Black
            // 
            this.Black.BackColor = System.Drawing.Color.Black;
            this.Black.Location = new System.Drawing.Point(10, 20);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(20, 20);
            this.Black.TabIndex = 0;
            this.Black.Click += new System.EventHandler(this.ColorClick);
            this.Black.MouseEnter += new System.EventHandler(this.ColorMouseEnter);
            this.Black.MouseLeave += new System.EventHandler(this.ColorMouseExit);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WidthLabel.Location = new System.Drawing.Point(463, 33);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(49, 17);
            this.WidthLabel.TabIndex = 2;
            this.WidthLabel.Text = "Width";
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.Location = new System.Drawing.Point(466, 53);
            this.WidthUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.WidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.Size = new System.Drawing.Size(46, 20);
            this.WidthUpDown.TabIndex = 3;
            this.WidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthUpDown.ValueChanged += new System.EventHandler(this.WidthChange);
            // 
            // SelectedColor
            // 
            this.SelectedColor.BackColor = System.Drawing.Color.Black;
            this.SelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectedColor.Location = new System.Drawing.Point(531, 52);
            this.SelectedColor.Name = "SelectedColor";
            this.SelectedColor.Size = new System.Drawing.Size(46, 46);
            this.SelectedColor.TabIndex = 31;
            // 
            // SelectedColorLabel
            // 
            this.SelectedColorLabel.AutoSize = true;
            this.SelectedColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedColorLabel.Location = new System.Drawing.Point(518, 33);
            this.SelectedColorLabel.Name = "SelectedColorLabel";
            this.SelectedColorLabel.Size = new System.Drawing.Size(71, 17);
            this.SelectedColorLabel.TabIndex = 32;
            this.SelectedColorLabel.Text = "Selected";
            // 
            // saveFile
            // 
            this.saveFile.Filter = "Png Image (.png)|*.png";
            this.saveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFile_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 709);
            this.Controls.Add(this.SelectedColorLabel);
            this.Controls.Add(this.SelectedColor);
            this.Controls.Add(this.WidthUpDown);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.ColorGroup);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Li and Ben\'s Ode to Paint!";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ColorGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentlyOpenedToolStripMenuItem;
        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.Panel Custom;
        private System.Windows.Forms.GroupBox ColorGroup;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.Panel Black;
        private System.Windows.Forms.Panel Gray;
        private System.Windows.Forms.Panel Maroon;
        private System.Windows.Forms.Panel White;
        private System.Windows.Forms.Panel Red;
        private System.Windows.Forms.Panel Yellow;
        private System.Windows.Forms.Panel Lime;
        private System.Windows.Forms.Panel Aqua;
        private System.Windows.Forms.Panel Blue;
        private System.Windows.Forms.Panel Fuchsia;
        private System.Windows.Forms.Panel LemonChiffon;
        private System.Windows.Forms.Panel SpringGreen;
        private System.Windows.Forms.Panel PowderBlue;
        private System.Windows.Forms.Panel MediumSlateBlue;
        private System.Windows.Forms.Panel DeepPink;
        private System.Windows.Forms.Panel SandyBrown;
        private System.Windows.Forms.Panel Sienna;
        private System.Windows.Forms.Panel BlueViolet;
        private System.Windows.Forms.Panel SteelBlue;
        private System.Windows.Forms.Panel DeepSkyBlue;
        private System.Windows.Forms.Panel DarkSlateGray;
        private System.Windows.Forms.Panel DarkKhaki;
        private System.Windows.Forms.Panel Purple;
        private System.Windows.Forms.Panel Navy;
        private System.Windows.Forms.Panel Teal;
        private System.Windows.Forms.Panel Green;
        private System.Windows.Forms.Panel Olive;
        private System.Windows.Forms.Panel Silver;
        private System.Windows.Forms.Panel SelectedColor;
        private System.Windows.Forms.Label SelectedColorLabel;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}

