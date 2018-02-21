﻿using System;
using System.Collections.Generic;
using System.Text;
using Waher.Content.Html.Elements;
using Waher.Content.Html.OpenGraph;

namespace Waher.Content.Html
{
	/// <summary>
	/// Contains meta-data about a page.
	/// 
	/// Protocols supported:
	/// The Open Graph protocol: http://ogp.me/
	/// Twitter Cards: https://developer.twitter.com/en/docs/tweets/optimize-with-cards/overview/markup
	/// </summary>
	public class PageMetaData
	{
		private ImageInformation[] images = null;
		private AudioInformation[] audio = null;
		private VideoInformation[] video = null;
		private string[] localeAlternate = null;
		private string title = null;
		private string type = null;
		private string url = null;
		private string description = null;
		private string determiner = null;
		private string locale = null;
		private string siteName = null;

		/// <summary>
		/// Contains meta-data about a page.
		/// 
		/// Protocols supported:
		/// The Open Graph protocol: http://ogp.me/
		/// Twitter Cards: https://developer.twitter.com/en/docs/tweets/optimize-with-cards/overview/markup
		/// </summary>
		public PageMetaData()
		{
		}

		/// <summary>
		/// Contains meta-data about a page.
		/// 
		/// Protocols supported:
		/// The Open Graph protocol: http://ogp.me/
		/// </summary>
		/// <param name="Doc">HTML Document</param>
		public PageMetaData(HtmlDocument Doc)
		{
			List<ImageInformation> Images = null;
			List<AudioInformation> Audio = null;
			List<VideoInformation> Video = null;
			List<string> LocaleAlternate = null;
			ImageInformation LastImage = null;
			AudioInformation LastAudio = null;
			VideoInformation LastVideo = null;
			string Name;
			string Value;

			if (Doc.Meta != null)
			{
				foreach (Meta Meta in Doc.Meta)
				{
					if (!Meta.HasAttributes)
						continue;

					Name = Value = null;

					foreach (HtmlAttribute Attr in Meta.Attributes)
					{
						switch (Attr.Name)
						{
							case "property":
								Name = Attr.Value;
								break;

							case "content":
								Value = Attr.Value;
								break;
						}
					}

					if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value))
						continue;

					switch (Name)
					{
						case "og:title":
							this.title = Value;
							break;

						case "twitter:title":
							if (string.IsNullOrEmpty(this.title))
								this.title = Value;
							break;

						case "og:type":
							this.type = Value;
							break;

						case "twitter:card":
							if (string.IsNullOrEmpty(this.type))
								this.type = Value;
							break;

						case "og:url":
							this.url = Value;
							break;

						case "og:image":
						case "og:image:url":
						case "twitter:image":
							if (Images != null)
							{
								LastImage = null;

								foreach (ImageInformation Image in Images)
								{
									if (Image.Url == Value)
									{
										LastImage = Image;
										break;
									}
								}

								if (LastImage != null)
									break;
							}

							LastImage = new ImageInformation()
							{
								Url = Value
							};

							if (Images == null)
								Images = new List<ImageInformation>();

							Images.Add(LastImage);
							break;

						case "og:image:secure_url":
							if (LastImage != null)
								LastImage.SecureUrl = Value;
							break;

						case "og:image:type":
							if (LastImage != null)
								LastImage.ContentType = Value;
							break;

						case "og:image:width":
							if (LastImage != null && int.TryParse(Value, out int i))
								LastImage.Width = i;
							break;

						case "og:image:height":
							if (LastImage != null && int.TryParse(Value, out i))
								LastImage.Height = i;
							break;

						case "og:image:alt":
						case "twitter:image:alt":
							if (LastImage != null)
								LastImage.Description = Value;
							break;

						case "og:audio":
							LastAudio = new AudioInformation()
							{
								Url = Value
							};

							if (Audio == null)
								Audio = new List<AudioInformation>();

							Audio.Add(LastAudio);
							break;

						case "og:audio:secure_url":
							if (LastAudio != null)
								LastAudio.SecureUrl = Value;
							break;

						case "og:audio:type":
							if (LastAudio != null)
								LastAudio.ContentType = Value;
							break;

						case "og:description":
							this.description = Value;
							break;

						case "twitter:description":
						case "description":
							if (string.IsNullOrEmpty(this.description))
								this.description = Value;
							break;

						case "og:determiner":
							this.determiner = Value;
							break;

						case "og:locale":
							this.locale = Value;
							break;

						case "og:locale:alternate":
							if (LocaleAlternate == null)
								LocaleAlternate = new List<string>();

							LocaleAlternate.Add(Value);
							break;

						case "og:site_name":
							this.siteName = Value;
							break;

						case "og:video":
							LastVideo = new VideoInformation()
							{
								Url = Value
							};

							if (Video == null)
								Video = new List<VideoInformation>();

							Video.Add(LastVideo);
							break;

						case "og:video:secure_url":
							if (LastVideo != null)
								LastVideo.SecureUrl = Value;
							break;

						case "og:video:type":
							if (LastVideo != null)
								LastVideo.ContentType = Value;
							break;

						case "og:video:width":
							if (LastVideo != null && int.TryParse(Value, out i))
								LastVideo.Width = i;
							break;

						case "og:video:height":
							if (LastVideo != null && int.TryParse(Value, out i))
								LastVideo.Height = i;
							break;
					}
				}
			}

			if (string.IsNullOrEmpty(this.title) && Doc.Title != null)
				this.title = Doc.Title.InnerHtml.Trim();
			
			this.images = Images?.ToArray();
			this.audio = Audio?.ToArray();
			this.video = Video?.ToArray();
			this.localeAlternate = LocaleAlternate?.ToArray();
		}

		/// <summary>
		/// Image representing page.
		/// </summary>
		public ImageInformation[] Images
		{
			get { return this.images; }
			set { this.images = value; }
		}

		/// <summary>
		/// Audio content
		/// </summary>
		public AudioInformation[] Audio
		{
			get { return this.audio; }
			set { this.audio = value; }
		}

		/// <summary>
		/// Video content
		/// </summary>
		public VideoInformation[] Video
		{
			get { return this.video; }
			set { this.video = value; }
		}

		/// <summary>
		/// Alternate locales
		/// </summary>
		public string[] LocaleAlternate
		{
			get { return this.localeAlternate; }
			set { this.localeAlternate = value; }
		}

		/// <summary>
		/// Title of page.
		/// </summary>
		public string Title
		{
			get { return this.title; }
			set { this.title = value; }
		}

		/// <summary>
		/// Type of page.
		/// </summary>
		public string Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// Canonical URL of page.
		/// </summary>
		public string Url
		{
			get { return this.url; }
			set { this.url = value; }
		}

		/// <summary>
		/// A description of the page.
		/// </summary>
		public string Description
		{
			get { return this.description; }
			set { this.description = value; }
		}

		/// <summary>
		/// A word that appears before the title.
		/// </summary>
		public string Determiner
		{
			get { return this.determiner; }
			set { this.determiner = value; }
		}

		/// <summary>
		/// Locale of information.
		/// </summary>
		public string Locale
		{
			get { return this.locale; }
			set { this.locale = value; }
		}

		/// <summary>
		/// Name of web site publishing page
		/// </summary>
		public string SiteName
		{
			get { return this.siteName; }
			set { this.siteName = value; }
		}

	}
}